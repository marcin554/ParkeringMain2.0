using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;


namespace Parkering2._0
{

    public class ConsoleMenu
    {
  

       
   
        //TAKE IN A VEHICLE
        //TAKE OUT A VEHICLE
        //SEARCH AFTER A VEHICLE
        //EXIT
        public class MenuChoice
        {

            string whatToDo = AnsiConsole.Prompt(
     new SelectionPrompt<string>()
    .Title("What you want to [green]do[/]?")
    .PageSize(10)
    .AddChoices(new[] {
            "Take in",  "Take out", "Move Vehicle", "Look after", "Exit","", "[red]Admin Tools[/]",
    }));
            



        }

        public class CountChart
        {

        }











    }
}
