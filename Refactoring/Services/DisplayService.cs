﻿using System;
using Refactoring.Services.Interfaces;

namespace Refactoring.Services
{
    public class DisplayService : IDisplayService
    {
        public string? ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string str)
        {
            Console.WriteLine(str);
        }
    }
}
