using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventureLibrary {
    public static class GameInfo {

        public static string Title = "" +
            "        ##            ##                                                                                \n" +
            "     /####             ##                                                                               \n" +
            "    /  ###             ##                                       #                                       \n" +
            "       /##             ## ##                                   ##                                       \n" +
            "      /  ##            ## ##                                   ##                                       \n" +
            "      /  ##        ### ##  ##    ###      /##  ###  /###     ######## ##   ####    ###  /###     /##    \n" +
            "     /    ##      ######### ##    ###    / ###  ###/ #### / ########   ##    ###  / ###/ #### / / ###   \n" +
            "     /    ##     ##   ####  ##     ###  /   ###  ##   ###/     ##      ##     ###/   ##   ###/ /   ###  \n" +
            "    /      ##    ##    ##   ##      ## ##    ### ##    ##      ##      ##      ##    ##       ##    ### \n" +
            "    /########    ##    ##   ##      ## ########  ##    ##      ##      ##      ##    ##       ########  \n" +
            "   /        ##   ##    ##   ##      ## #######   ##    ##      ##      ##      ##    ##       #######   \n" +
            "   #        ##   ##    ##   ##      ## ##        ##    ##      ##      ##      ##    ##       ##        \n" +
            "  /####      ##  ##    /#   ##      /  ####    / ##    ##      ##      ##      /#    ##       ####    / \n" +
            " /   ####    ## / ####/      ######/    ######/  ###   ###     ##       ######/ ##   ###       ######/  \n" +
            "/     ##      #/   ###        #####      #####    ###   ###     ##       #####   ##   ###       #####   \n" +
            "#                                                                                                       \n" +
            " ##               ";
        public static string Intro = "" +
            "__ __   \n" +
            "\\ v /  our goal is to traverse the jungles of South America, in search of the lost city of the dead —\n" +
            " \\ /   the ancient Necropolis of a little known branch of the Inca. Rumor has it that some of these\n" +
            " |_|   tribesman still exist today, and jealously guard their secrets with beastly adroitness.\n\n" +
            "     You must take on the role of one of the greatest adventurers of all time and, using the skills\n" +
            "you've honed from years of tracking and hunting, and numerous movie and video game appearances,\n" +
            "locate the Necropolis and extract the golden head of Ocxaloc, king of the Inca, from the throne\n" +
            "room where it is enshrined.";
        public static string Indy = "" +
            " __ \n" +
            "/_ |  Dr. Henry \"Indiana\" Jones is a professor of archaeology and anthropology whose prowess\n" +
            " | |  for field work is well known among academics. It was he who was the first to deduce the\n" +
            " | |  general location of the Necropolis, and his strong sense of justice has driven him to\n" +
            " | |  attempt to preserve its relics before they can fall into the hands of mere grave robbers.\n" +
            " |_|  He includes his bitter rival, Rene Belloq, in that camp.";
        public static string Lara = "" +
            " ___  \n" +
            "|__ \\   Lara Croft is known, by more charitable types, as a collector of antiquities. The less\n" +
            "   ) |  sophisticated crowd calls her a thief, a tomb raider. Regardless of one's philosophy\n" +
            "  / /   of acquisition, she certainly does what she does with style and grace. She is especially\n" +
            " / /_   adept in the use of her twin knives, and will relieve a foe of his life just as readily as\n" +
            "|____|  his belongings.";
        public static string Allan = "" +
            " ____  \n" +
            "|___ \\   Allan Quatermain is a real \"man's man\". This experienced big-game hunter oozes\n" +
            "  __) |  machismo out of every pore. His marksmanship is second to none; put a firearm in his\n" +
            " |__ <   hand and he's nearly unbeatable. Rumor has it that he gained immortality on one of\n" +
            " ___) |  his adventures, and he considered this the worst thing that could have happened.\n" +
            "|____/   Bored with a life devoid of danger, he takes on any task just for a little diversion.";
        public static string Harry = "" +
            " _  _   \n" +
            "| || |   \"Pitfall\" Harry made his debut in 1982 on home arcade consoles. His was one of\n" +
            "| || |_  Activision's first successful titles in the home video game market. He is really\n" +
            "|__   _| athletic, and prides himself on his Tarzan impressions as he swings through the\n" +
            "   | |   jungle shouting at the top of his voice. Harry has a lot of experience exploring\n" +
            "   |_|   the jungle and evading 8-bit scorpions.";
        public static string Celebration = "" +
            " a88888b.  88888888b dP         88888888b  888888ba   888888ba   .d888888  d888888P dP  .88888.  888888ba  \n" +
            "d8'   `88  88        88         88         88    `8b  88    `8b d8'    88     88    88 d8'   `8b 88    `8b \n" +
            "88        a88aaaa    88        a88aaaa    a88aaaa8P' a88aaaa8P' 88aaaaa88a    88    88 88     88 88     88 \n" +
            "88         88        88         88         88   `8b.  88   `8b. 88     88     88    88 88     88 88     88 \n" +
            "Y8.   .88  88        88         88         88    .88  88     88 88     88     88    88 Y8.   .8P 88     88 \n" +
            " Y88888P'  88888888P 88888888P  88888888P  88888888P  dP     dP 88     88     dP    dP  `8888P'  dP     dP ";
        public static ConsoleColor[] Party = new ConsoleColor[] {
            ConsoleColor.Cyan, 
            ConsoleColor.Green, 
            ConsoleColor.Red, 
            ConsoleColor.Yellow, 
            ConsoleColor.Magenta,
            ConsoleColor.Blue,
            ConsoleColor.White
        };

    }   // end class
}


