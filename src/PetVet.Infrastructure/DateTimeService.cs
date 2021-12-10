using PetVet.Application.Common.Interfaces;
using System;

namespace PetVet.Infrastructure
{
    internal class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;

        public int CurrentYear => DateTime.Now.Year;
    }
}