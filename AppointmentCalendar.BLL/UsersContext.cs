using AppointmentCalendar.BLL.Configuration;
using AppointmentCalendar.BLL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentCalendar.BLL
{
    public  class UsersContext:DbContext
    {
        public UsersContext(DbContextOptions<UsersContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)//TODO dodanie uzytkownika do tabeli tylko poprzez migracje!!
        {
            //TODO dodac to jesli baza nie istnieje dodaje do bazy z seed i wlasciwosci do bazy
            //modelBuilder.Seed();//wczytanie wejsciowych danych do bazy z serwisu
            //modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);//nakladanie wlasciwosci na baze
        }
    }
}
