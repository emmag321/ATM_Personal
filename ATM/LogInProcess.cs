using System;
using System.Collections.Generic;

public class LogInProcess
{
    public Card Card { get; private set; }

    private bool isLogged;
    private List<Transaction> transactionList;

    public LogInProcess()
    {
        this.Card = null;
        this.isLogged = false;
        transactionList = new List<Transaction>();
    }

    public LogInProcess(Card card)
    {
        this.InsertCard(card);
        transactionList = new List<Transaction>();
    }

    public void InsertCard(Card card)
    {
        if (card == null)
            throw new Exception();
        this.Card = card;
    }

    private bool VerifyCard(Card card)
    {
        if (card.ExpiryDate.Year < DateTime.Now.Year && card.ExpiryDate.Month < DateTime.Now.Month)
        {
            return false;
        }

        return Mod10.Validate(card.CardNumber);
    }

    public void GiveBackCard()
    {
        this.Card = null;
    }

    public bool LogIn(string pin)
    {
        if(this.Card == null)
            throw new Exception("Unable to log in because no card has been inserted.");

        if(this.isLogged)
            throw new Exception("User is already logged in");

        if(this.Card.CheckPin(pin)) 
        {
            this.isLogged = true;
            return true;
        }
        else
        {
            return false;
        }
    
    }

    public void LogOut(bool printReceive)
    {
        if(!this.isLogged)
        {
            throw new InvalidOperationException("No user is logged in.");
        }

        if (printReceive)
        {
            this.PrintReceive();
        }

        this.GiveBackCard();
    }

    private void PrintReceive()
    {
        if(this.transactionList.Count <= 0)
        {
            throw new InvalidOperationException("No transaction has been performed.");
        }

        string output = "Receive for the ATM transactions of " + DateTime.Now + "\n";
        output = "----------\n";
           
        foreach (Transaction transaction in transactionList)
        {
            output += transaction + "\n";
        }

        output += "----------";

        // TODO: Implement a better printing simulation
        Console.Write(output);
    }
}