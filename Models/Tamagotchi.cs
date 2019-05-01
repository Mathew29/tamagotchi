using System.Collections.Generic;
using System;

namespace Tamagotchi.Models
{
  public class Item
  {
    private int _food;
    private int _attention;
    private int _rest;
    private int _poop;
    private int _id;
    private int _happiness;
    private int _hunger;
    private static List<Item> _instances = new List<Item> {};
    private string _name;
    private bool _dead;

    public Item (string name)
    {
      _name = name;
      _instances.Add(this);
      _id = _instances.Count;
      _food = 5;
      _attention = 50;
      _rest = 50;
      _poop = 0;
      _hunger = 50;
      _happiness = 50;
      _dead = false;
    }

    public bool IsDead()
    {
      return _dead;
    }

    public string GetName()
    {
      return _name;
    }

    public void SetName(string newName)
    {
      _name = newName;
    }

    public int GetId()
    {
      return _id;
    }

    public static List<Item> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Item Find(int searchId)
    {
      return _instances[searchId-1];
    }

    public int GetFood()
    {
      return _food;
    }

    public void SetFood(int food)
    {
      _food = food;
    }

    public int GetAttention()
    {
      return _attention;
    }

    public void SetAttention(int attention)
    {
      _attention = attention;
    }

    public int GetRest()
    {
      return _rest;
    }

    public void SetRest(int rest)
    {
      _rest = rest;
    }

    public int GetPoop()
    {
      return _poop;
    }

    public void SetPoop(int poop)
    {
      _poop = poop;
    }

    public int GetHunger()
    {
      return _hunger;
    }

    public int GetHappiness()
    {
      return _happiness;
    }

    public void SetHunger(int hunger)
    {
      _hunger = hunger;
    }

    public void Tick()
    {
      _attention--;
      _hunger--;
      _rest--;
      Random rand = new Random();
      if(rand.Next(0,100) < _hunger)
      {
        if(_food > 0)
        {
        _food--;
        }else{
          _happiness -= 10;
        }
      }

      _happiness = _happiness + (_rest - 50) + (_hunger-50) + (_attention-50);
      _happiness = _happiness - (10*_poop);
      if(_happiness < 0)
      {
        _dead = true;
      }
      if(rand.Next(0,10) == 0)
      {
        _poop++;
        _hunger -= 10;
      }
      if(_hunger > 100)
      {
        _hunger = 100;
      }
      if(_happiness> 100)
      {
        _happiness = 100;
      }
      if(_attention> 100)
      {
        _attention = 100;
      }
      if(_rest> 100)
      {
        _rest = 100;
      }
    }

  }
}
