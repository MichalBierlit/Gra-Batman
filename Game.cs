using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Batman.RiddlerChallenge;

namespace Batman
{
    public class Game
    {
        private Player player;
        private Dictionary<string, Location> locations;
        private List<string> capturedVillains = new List<string>();
        private HashSet<string> upgradedForVillains = new HashSet<string>();
        private bool isFirstTimeInBatcave = true;
        private bool pingwinZbadany = false;
        private int crimeAlleyVisits = 0;
        private int penguinVisits = 0;
        private bool NigmaZbadany = false;
        private bool CrimeAlleyZbadana=false;
        private bool pingwinUciekł = false;
        private bool hakowaniePingwinaUdane = false;
        private bool kanalZbadany = false;
        private bool GordonInfo = false;
        private bool RaceScore=false;


        public void Start()
        {
            Console.Title = "Batman: Mroczne zagadki Gotham City";
            Console.WriteLine("Witaj w Gotham Mroczny Rycerzu!");
            InitializeLocations();
            player = new Player();
            player.MoveTo(locations["Batcave"]);
            GameLoop();
        }

        private void InitializeLocations()
        {
            locations = new Dictionary<string, Location>();

            var crimeAlley = new Location("Crime Alley", "Mroczna uliczka, gdzie wszystko się zaczęło.");
            var arkham = new Location("Arkham Asylum", "Szpital psychiatryczny dla najbardziej niebezpiecznych szaleńców.");
            var batcave = new Location("Batcave", "Baza Batmana pełna gadżetów (każda wizyta dodaje jeden batarang).");
            var wayneTower = new Location("Wayne Tower", "Nowoczesny biurowiec należący do Bruce'a Wayne’a (oferuje ulepszenia Batmana po ujęciu złoczyńcy).");
            var penguinClub = new Location("Penguin's Nightclub", "Ekskluzywny klub nocny prowadzony przez Pingwina.");
            var police = new Location("Police station", "Posterunek Policji pod kierownictwem komisarza Gordona.");
            var orphanage = new Location("Old orphanage", "Stary opuszczony sierociniec - dawna siedziba Edwarda Nigmy.");
            var casino = new Location("Casino Gotham", "Najbardziej szemrane kasyno w Gotham. Hazard, dym i przekupione szczęście.");
            var canals = new Location("Canal Hideout", "Wilgotne, cuchnące kanały pod Gotham. Idealna nora dla Pingwina.");


            crimeAlley.Neighbors.Add("Batcave", batcave);
            crimeAlley.Neighbors.Add("Penguin's Nightclub", penguinClub);
            crimeAlley.Neighbors.Add("Arkham Asylum", arkham);
            crimeAlley.Neighbors.Add("Canal Hideout", canals);    

            batcave.Neighbors.Add("Crime Alley", crimeAlley);
            batcave.Neighbors.Add("Wayne Tower", wayneTower);
            batcave.Neighbors.Add("Police station", police);
            batcave.Neighbors.Add("Casino Gotham", casino);

            arkham.Neighbors.Add("Crime Alley", crimeAlley);
            arkham.Neighbors.Add("Old orphanage", orphanage);

            wayneTower.Neighbors.Add("Batcave", batcave);
            wayneTower.Neighbors.Add("Police station", police);
            wayneTower.Neighbors.Add("Casino Gotham", casino);
            wayneTower.Neighbors.Add("Canal Hideout", canals);
            
            canals.Neighbors.Add("Wayne Tower", wayneTower);
            canals.Neighbors.Add("Crime Alley",crimeAlley);

            casino.Neighbors.Add("Wayne Tower", wayneTower);
            casino.Neighbors.Add("Batcave", batcave);

            penguinClub.Neighbors.Add("Crime Alley", crimeAlley);
            penguinClub.Neighbors.Add("Old orphanage", orphanage);
            penguinClub.Neighbors.Add("Police Station", police);

            police.Neighbors.Add("Wayne Tower", wayneTower);
            police.Neighbors.Add("Batcave", batcave);
            police.Neighbors.Add("Old orphanage", orphanage);
            police.Neighbors.Add("Penguin's Nightclub", penguinClub);

            orphanage.Neighbors.Add("Penguin's Nightclub", penguinClub);
            orphanage.Neighbors.Add("Police station", police);
            orphanage.Neighbors.Add("Arkham Asylum", arkham);

            locations.Add(police.Name, police);
            locations.Add(crimeAlley.Name, crimeAlley);
            locations.Add(batcave.Name, batcave);
            locations.Add(arkham.Name, arkham);
            locations.Add(wayneTower.Name, wayneTower);
            locations.Add(penguinClub.Name, penguinClub);
            locations.Add(orphanage.Name, orphanage);
            locations.Add(canals.Name, canals);
        }

        public void GameLoop()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("                                                        THE BATMAN\n");
                Console.Beep(400,600);
                Console.ResetColor();

                if (player.CurrentLocation.Name == "Batcave" && isFirstTimeInBatcave)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Alfred: \"Mistrzu Wayne, zostawiłem dla Ciebie nowe informacje na Batkomputerze. Gotham potrzebuje Cię bardziej niż kiedykolwiek.\"");
                    Console.WriteLine("Naciśnij Enter, aby odtworzyć wiadomość...");
                    Console.ReadLine();
                    Console.Beep(400, 600);
                    Console.WriteLine("Alfred: \"Paniczu, mamy problem. Poważny problem.\"");
                    Console.WriteLine("Alfred: \"Zebrałem dane z lokalnych szpitali... zaczęły się pojawiać przypadki dziwnych mutacji u ludzi z nocnego klubu Pingwina.\"");
                    Console.WriteLine("Alfred: \"Według plotek Joker stworzył nowy narkotyk – nazywają go 'Smylex-X'.\"");
                    Console.WriteLine("Alfred: \"Powoduje psychozę, zniekształcenia ciała, a w niektórych przypadkach... śmierć w uśmiechu.\"");
                    Console.WriteLine("Alfred: \"Pingwin rozprowadza narkotyk w swoim klubie. Joker zarabia, a Gotham płonie od środka.\"");
                    Console.WriteLine("Alfred: \"Sugeruję, by udał sie Panicz do Crime Alley, gdyż z raportu poliycjnego wynika ze tam doszło do wiekszości szemranych transakcji. Może znajdziemy tam odpowiedzi.\"");
                    Console.WriteLine("\nNaciśnij Enter, by kontynuować...");
                    Console.ReadLine();
                    Console.ResetColor();
                    isFirstTimeInBatcave = false;
                    
                }
                if (player.CurrentLocation.Name == "Batcave")
                {
                    player.AddBatarang();
                    Console.WriteLine($"Batarangi: {player.Batarangs}/{player.MaxBatarangs}");
                }

                Console.WriteLine($"Obecna lokalizacja: {player.CurrentLocation.Name}");
                Console.WriteLine($"{player.CurrentLocation.Description}\n");
                



                if (player.CurrentLocation.Name == "Crime Alley")
                {
                    crimeAlleyVisits++;

                    if (crimeAlleyVisits % 3 == 0) // co trzecie odwiedzenie
                    {
                        Console.WriteLine("Znowu trafiasz do Crime Alley... ale tym razem czeka na Ciebie oddział zbirów!");
                        var enemy1 = new Enemy("Zbir 1", 35, 22, 2);
                        var enemy2 = new Enemy("Zbir z pistoletem", 25, 35, 8);

                        CombatSystem.StartCombat(player, enemy1);
                        CombatSystem.StartCombat(player, enemy2);
                    }
                    else if (crimeAlleyVisits == 1 )
                    {

                        Console.WriteLine("W zaułku widzisz zakapturzoną  postać z pakunkiem, która na twój widok zaczyna uciekać w popłochu. Co robisz?\n");
                        Console.WriteLine("1. Gonić\n2. Podnieść pakunek");
                        
                        string choice = Console.ReadLine();
                        if (choice == "1")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Zostałeś otoczony przez zbirów. Czas na walkę!");
                            var thug = new Enemy("Zbir z nożem", 40, 19, 5);
                            var thug1 = new Enemy("Zbir z kijem baseballowym", 50, 25, 10);
                            CombatSystem.StartCombat(player, thug);
                            CombatSystem.StartCombat(player, thug1);
                            Console.ResetColor();
                            Console.WriteLine("Po przesłuchaniu  pokonanych zbirów mówią, że sa najemnikami dealującymi dla Pingwina...Czas poważnie z nim pogadać!\n");
                            CrimeAlleyZbadana=true;
                        }
                        else if (choice == "2")
                        {
                            Console.Clear();
                            Console.WriteLine("To próbka Smylex-X. Na fiolce widnieje 'Specjalny prezencik dla  Oswalda  Cobblepot'a od stęsknionego J'. Joker tu był.\n");
                            Console.WriteLine("Musisz poważnie pogadać z Pingwinem\n");
                            CrimeAlleyZbadana = true;

                        }
                        else
                        {
                            Console.WriteLine("Nieprawidłowy wybór.");
                            Console.ReadLine();
                        }
                    }
                }
                if (player.CurrentLocation.Name == "Casino Gotham")
                {   
                    Effects.CasinoGothamIntro();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(@"
                    ................................................................................
                    .   ██████╗ █████╗ ███████╗██╗███╗   ██╗ ██████╗     ██████╗  ██████╗ ████████╗ .
                    .  ██╔════╝██╔══██╗╚══███╔╝██║████╗  ██║██╔═══██╗    ██╔══██╗██╔═══██╗╚══██╔══╝ .
                    .  ██║     ███████║  ███╔╝ ██║██╔██╗ ██║██║   ██║    ██████╔╝██║   ██║   ██║    .
                    .  ██║     ██╔══██║ ███╔╝  ██║██║╚██╗██║██║   ██║    ██╔═══╝ ██║   ██║   ██║    .
                    .  ╚██████╗██║  ██║███████╗██║██║ ╚████║╚██████╔╝    ██║     ╚██████╔╝   ██║    .
                    .   ╚═════╝╚═╝  ╚═╝╚══════╝╚═╝╚═╝  ╚═══╝ ╚═════╝     ╚═╝      ╚═════╝    ╚═╝    .
                    ................................................................................
                    .   ██████╗  ██████╗ ████████╗██╗  ██╗ █████╗ ███╗   ███╗                         .
                    .  ██╔═══  ╗██╔═══██╗╚══██╔══╝██║  ██║██╔══██╗████╗ ████║                         .
                    .  ██║     ║██║   ██║   ██║   ███████║███████║██╔████╔██║                         .
                    .  ██║   ██║██║   ██║   ██║   ██╔══██║██╔══██║██║╚██╔╝██║                         .
                    .  ╚██████╔╝╚██████╔╝   ██║   ██║  ██║██║  ██║██║ ╚═╝ ██║                         .
                    .   ╚═════╝  ╚═════╝    ╚═╝   ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝     ╚═╝                         .
                    ................................................................................
                    ");
                    Console.ResetColor();
                    Console.WriteLine("1. Ruletka (szansa na instant win)");
                    Console.WriteLine("2. Blackjack (1v1 z krupierem)");
                    Console.WriteLine("3. Powrót");
                    Console.Write("Wybierz opcję: ");
                    string input11 = Console.ReadLine();
                    if (input11 == "1")
                    {
                        Console.WriteLine(" Witamy w Casino Gotham – obstaw liczbę od 0 do 99.");
                        Console.WriteLine(" Traf — a kończysz grę z bogactwem i chwałą. Nie trafisz? Gotham nadal cię potrzebuje.");

                        Console.Write(" Podaj swój typ (0-99): ");
                        string input1 = Console.ReadLine();

                        if (int.TryParse(input1, out int guess) && guess >= 0 && guess <= 99)
                        {
                            Random rng = new Random();
                            int result = rng.Next(0, 100);
                            Thread.Sleep(300);
                            Console.Beep(900, 200);
                            Console.Beep(1100, 200);
                            Console.Beep(1300, 200);
                            Console.Beep(900, 200);
                            Console.Beep(1100, 200);
                            Console.Beep(1300, 200);
                            Console.Beep(900, 200);
                            Console.Beep(1100, 200);
                            Console.Beep(1300, 200);
                            Thread.Sleep(200);
                            Console.WriteLine($" Losowanie... Wynik: {result}");

                            if (guess == result)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine(@"
                             GRATULACJE! 
                             Trafiłeś idealnie – wygrywasz całą grę!
                             Gotham nie potrzebuje bohatera, potrzebuje SZCZĘŚCIARZA.
                            ");
                                Console.ResetColor();
                                Environment.Exit(0);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("\n Niestety... Los się odwrócił. Ale możesz próbować dalej.");
                                Console.ResetColor();
                            }
                        }
                        else
                        {
                            Console.WriteLine(" Wprowadź liczbę od 0 do 99.");
                        }

                        Console.WriteLine("\n Naciśnij Enter, aby kontynuować...");
                        Console.ReadLine();
                    }
                    else if (input11 == "2")
                    {
                        Casino.PlayBlackjack();
                        
                    }
                    else if (input11 == "3")
                    {
                        Console.WriteLine("Opuszczasz Casino Gotham...");
                        player.MoveTo(locations["Batcave"]);
                        Console.WriteLine($"Obecna lokalizacja: {player.CurrentLocation.Name}");
                        Console.WriteLine($"{player.CurrentLocation.Description}\n");
                    }
                }
                

                if (player.CurrentLocation.Name == "Penguin's Nightclub" && CrimeAlleyZbadana == false) { Console.WriteLine("Głośno, mnóstwo ludzi, ale brak śladów Pingwina... (zgodnie z poleceniem Alfreda zalecane jest wrócic do CrimeAlley) \n"); }

                if (player.CurrentLocation.Name == "Penguin's Nightclub" && CrimeAlleyZbadana==true)
                {
                    RaceStatus status = new RaceStatus();
                    penguinVisits++;

                    if (penguinVisits == 1)
                    {
                        Console.WriteLine("Po wejściu do klubu zauważasz na loży Pingwina odbierającego walizke z pieniędzmi, już zaczynasz ruszać w jego storne, ale nagle z cienia wyłania się zmutowany ochroniarz!\n");
                        Console.ForegroundColor= ConsoleColor.Red;
                        var guard = new Enemy("Zmutowany ochroniarz", 60, 25, 18);
                        CombatSystem.StartCombat(player, guard);
                        Console.ResetColor();
                        Console.WriteLine("W międzyczasie podejrzany Pingwin zbiegł...\n");
                        Console.WriteLine("1.Możesz ruszyć w pościg Batmobilem\n2.Na spokojnie przeszukać siedzibę Pingwina\n ");
                        string choice1 = Console.ReadLine();
                        Console.Clear();

                        if (choice1 == "1")
                        {
                            Batmobil batmobil = new Batmobil();
                            PenguinMaserati pingwin = new PenguinMaserati();


                            RaceSystem.PursuitRace(batmobil, pingwin, status);
                            if (status.WyscigWygrany == true)
                            {
                                
                                Console.WriteLine("\nAresztujesz Pingwina i zabierasz go na komisariat w celu przesłuchaniu i znalezeniu Jokera");
                                Thread.Sleep(3000);
                                Console.Clear();
                                player.MoveTo(locations["Police station"]);
                                Console.WriteLine($"Obecna lokalizacja: {player.CurrentLocation.Name}");
                                Console.WriteLine($"{player.CurrentLocation.Description}\n");
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.WriteLine("Pingwin (z kajdankami na rękach):");
                                Console.WriteLine("\"Ej, ej! Nie jestem żadnym mózgiem tej operacji! Ja tylko udostępniałem lokal, rozumiesz? To wszystko przez tego pieprzonego klauna! Joker pociąga za wszystkie sznurki!\"");
                                Console.WriteLine();
                                Console.WriteLine("(krztusi się ze złości)");
                                Console.WriteLine();
                                Console.WriteLine("\"On tylko wykorzystał moje kontakty… Ja nie miałem pojęcia, co pakuję do tych walizek! Przysięgam!\"");
                                Console.WriteLine();
                                Console.WriteLine("(robi przerwę, patrząc ci prosto w oczy)");
                                Console.WriteLine();
                                Console.WriteLine("\"Ale... jeśli chcesz go złapać, to się pospiesz. Najnowsza dostawa Smylex-X ma trafić do jakiegoś przeklętego miejsca…\"");
                                Console.WriteLine("\"Do Starego Sierocińca. Tam znajdziesz odpowiedzi. I może... jego.\"");
                                Console.ResetColor();
                                Console.WriteLine("\n(Zalecane odwiedzenie Wayne Tower w celu odebrania upgarade'u statystyk po złapaniu Pingwina)") ;
                                Console.WriteLine();
                                pingwinZbadany = true;
                                RaceScore=true;
                                capturedVillains.Add("Pingwin");
                                
                            }
                            else
                            {
                                Console.WriteLine("\nMusisz inaczej dopaść Pingwina");
                                pingwinUciekł = true;
                            }

                        }
                        else if (choice1 == "2")
                        {
                            Console.WriteLine("W biurze Pingiwina znajdujesz notatnik z adresami dostaw, okazuje się ze handel przebiega przez Stary Sierociniec (Old Orphange)...musisz to zbadac!");
                            pingwinZbadany = true;
                            pingwinUciekł = true;

                        }
                        else
                        {
                            Console.WriteLine("Nieprawidłowy wybór.");
                            Console.ReadLine();
                        }

                    }
                    else if (status.WyscigWygrany == false && GordonInfo==false && RaceScore==false)
                    {
                        Console.WriteLine("Udaj sie na Komisariat do Gordona by wrócic na trop Pingwina...");
                        pingwinUciekł = true;
                        GordonInfo = true;

                    }
                    else if (penguinVisits > 1 && pingwinZbadany && pingwinUciekł)
                    {
                        Console.WriteLine("Musisz znaleźć wiecej poszlak zeby tu wrocic...");
                    }
                    else if (penguinVisits > 1 && !pingwinZbadany)
                    {
                        Console.WriteLine("To miejsce juz nie ma tajemnic");
                    }

                }

                if (player.CurrentLocation.Name == "Old orphanage")
                {
                    if (pingwinZbadany == true && NigmaZbadany == false)
                    {
                        Console.Clear();
                        Console.WriteLine(" Gdy tylko przekraczasz bramę Starego Sierocińca, metalowe wrota zatrzaskują się z hukiem za tobą.");
                        Console.WriteLine("Wszystko wokół ciemnieje, światła zaczynają pulsować na zielono...");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(" *Z megafonu rozlega się donośny, maniakalny śmiech*");
                        Console.WriteLine("\"HAHAHAHAHA!\"");
                        Console.WriteLine();
                        Console.WriteLine(" Głos: \"Witaj, Batmanie...\"");
                        Console.WriteLine("\"Wiedziałem, że prędzej czy później trafisz do mojego małego laboratorium zagadek...\"");
                        Console.WriteLine();
                        Console.WriteLine("\"Nazywają mnie Edward Nygma. Ale Ty możesz mówić mi... Riddler.\"");
                        Console.WriteLine();
                        Console.WriteLine(" \"Sierociniec? Hah! To nie dom dziecka. To pułapka. I Ty, Rycerzu Ciemności, jesteś moim gościem honorowym.\"");
                        Console.WriteLine();
                        Console.WriteLine("\"Jeśli chcesz się stąd wydostać i dowiedzieć się, po co narkotyk trafił właśnie tutaj...\"");
                        Console.WriteLine("\"...musisz rozwiązać TRZY z moich najwspanialszych zagadek.\"");
                        Console.WriteLine();
                        Console.WriteLine("\"Powodzenia. Będziesz go potrzebował...\"");
                        Console.WriteLine(" *Śmiech rozbrzmiewa raz jeszcze, a w pomieszczeniu zapalają się zielone światła nad drzwiami z numerem '1'*");
                        Console.WriteLine();
                        Console.ResetColor();
                        Console.WriteLine("Naciśnij Enter, aby wejść do pierwszego pokoju zagadek...");
                        Console.ReadLine();
                        bool riddlerSolved = RiddlerChallenge.RunRiddles();
                        if (riddlerSolved)
                        {
                            
                            capturedVillains.Add("Riddler");
                            NigmaZbadany = true;
                            Thread.Sleep(3500);
                            Console.Clear();
                            player.MoveTo(locations["Police station"]);
                            
                            Console.WriteLine(" Riddler (skuty kajdankami, siedząc w pokoju przesłuchań):");
                            Console.ForegroundColor= ConsoleColor.Green;
                            Console.WriteLine("\"Hah... A więc jednak mnie złapałeś, Nietoperzu. Gratulacje. Czasem ślepej wiewiórce też się trafi orzech.\"");
                            Console.WriteLine();
                            Console.WriteLine("\"Ale powiedz mi jedno, detektywie... czy naprawdę wierzysz, że to JA pociągałem za wszystkie sznurki?\"");
                            Console.WriteLine("\"Jestem tylko architektem zagadek. Tym, który pokazuje Ci, jak mało naprawdę wiesz o swoim mieście.\"");
                            Console.WriteLine();
                            Console.WriteLine("\"Smylex-X? Tak, wiem. Wiem, co robiliśmy. Ale to nie była moja gra, tylko JEGO...\"");
                            Console.WriteLine("(spuszcza głowę, uśmiecha się krzywo)");
                            Console.WriteLine();
                            Console.WriteLine("\"Jeśli naprawdę chcesz zrozumieć, kto steruje tym szaleństwem, musisz udać się tam, gdzie królują obłąkani.\"");
                            Console.WriteLine("\"Do miejsca, gdzie wszystko się zaczęło... i gdzie wszystko może się zakończyć.\"");
                            Console.WriteLine();
                            Console.WriteLine(" \"Idź do Arkham, Nietoperzu. Joker już na Ciebie czeka. I, o tak... ma dla Ciebie niespodziankę.\"");
                            Console.WriteLine();
                            Console.WriteLine("*Riddler śmieje się cicho, patrząc prosto w twoje oczy, jakby znał zakończenie tej historii.*");
                            Console.ResetColor();
                            Console.WriteLine("\n(Zalecane odwiedzenie Wayne Tower w celu odebrania upgarade'u statystyk po złapaniu Riddlera)");
                            Console.WriteLine("\nNaciśnij Enter, aby opuścić komisariat...");
                            Console.ReadLine();
                           
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n Riddler: \"Pudło! Zaczynamy od początku, Nietoperzu!\"");
                            Console.ResetColor();
                            Console.WriteLine("Naciśnij Enter, by spróbować ponownie...");
                            Console.ReadLine();
                        }
                        


                    }
                    else if(NigmaZbadany==true)
                    {
                        Console.WriteLine("JUŻ ZŁAPAŁEŚ RIDDLERA!\n");
                    }
                    else
                    {

                        Console.WriteLine("Sierociniec świeci pustkami...\n");


                    }
                }
                if (player.CurrentLocation.Name == "Police station")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("----- RAPORT ZATRZYMAŃ -----");
                    Console.WriteLine($"Liczba ujętych przestępców: {capturedVillains.Count}");
                    Console.ResetColor();

                    if (capturedVillains.Count > 0)
                    {
                        for (int i = 0; i < capturedVillains.Count; i++)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine($"{i + 1}. {capturedVillains[i]}");
                            Console.ResetColor();
                        }
                    }
                    else
                    {   Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Brak zatrzymań. Brak wyników. Komisarz Gordon kręci głową z rozczarowaniem.");
                        Console.ResetColor();
                    }
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("-----------------------------\n");
                    Console.ResetColor();
                    if (pingwinUciekł==true && !hakowaniePingwinaUdane  && GordonInfo==true)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Gordon: \"Mamy nowy trop. Jedna z dostaw Smylex-X była oznaczona jako 'COLD STORAGE 92'.\"");
                        Console.WriteLine("Gordon: \"Wygląda na to, że Pingwin ukrywa się gdzieś w kanałach. Spróbuj znaleźć jego dokładną lokalizacje  przez super-komputer w Wayne Tower.\"");
                        Console.ResetColor();
                        
                    }


                }
                
                if (player.CurrentLocation.Name == "Wayne Tower")
                {
                    Console.WriteLine(" Witaj w  centrali Batmana i Luciusa Foxa\n");

                   
                    var pendingUpgrades = capturedVillains.Where(v => !upgradedForVillains.Contains(v)).ToList();

                    if (pendingUpgrades.Count == 0)
                    {   Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("Lucius: „Nie mamy obecnie nowych raportów. Wracaj na patrol, Panie Wayne.”");
                        Console.ResetColor();
                    }
                    else
                    {
                        foreach (var villain in pendingUpgrades)
                        {
                            Console.WriteLine($" Raport: Złapano {villain}. Przetwarzam dane...");

                            Console.WriteLine("Możesz odebrać nagrodę za ujęcie:");
                            Console.WriteLine("1. Siła ataku (+10)");
                            Console.WriteLine("2. Obrona (+5)");
                            Console.WriteLine("3. Limit batarangów (+1)");
                            Console.Write("Wybierz opcję: ");
                            string choice = Console.ReadLine();

                            switch (choice)
                            {
                                case "1":
                                    player.UpgradeAttack();
                                    break;
                                case "2":
                                    player.UpgradeDefense();
                                    break;
                                case "3":
                                    player.UpgradeBatarangLimit();
                                    break;
                                default:
                                    Console.WriteLine(" Nieprawidłowy wybór. Ulepszenie pominięte.");
                                    break;
                            }

                            upgradedForVillains.Add(villain); 
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(" Ulepszenie aktywne. Lucius: „Powodzenia, Panie Wayne.”\n");
                            Console.ResetColor ();
                        }
                    }
                    


                    Console.WriteLine("Naciśnij Enter, aby kontynuować...");
                    Console.ReadLine();
                }
                if (player.CurrentLocation.Name == "Wayne Tower" && pingwinUciekł && !hakowaniePingwinaUdane && GordonInfo==true)
                {
                    Console.Clear();
                    Console.WriteLine("                                       BATKOMPUTER:");
                    Console.WriteLine(" \n Chcesz przeprowadzić hakowanie systemu miejskiego w poszukiwaniu Pingwina? (T/N)");
                    string hackInput = Console.ReadLine().ToUpper();

                    if (hackInput == "T")
                    {
                        bool success = PenguinHack.StartHack();
                        if (success)
                        {
                            hakowaniePingwinaUdane = true;
                            Console.WriteLine(" Znaleziono lokalizację Pingwina! Nowa lokacja: Canal Hideout.");
                        }
                        else
                        {
                            Console.WriteLine(" Hakowanie nie powiodło się.");
                        }
                    }
                }
                if (player.CurrentLocation.Name == "Canal Hideout" && !kanalZbadany && pingwinUciekł==true && GordonInfo==true)
                {
                    Console.Clear();
                    Console.WriteLine(" W kanałach czujesz zimno i smród. W cieniu majaczy znajoma sylwetka...\n");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Pingwin: \"Batman?! Co ty tu robisz... To moje bagno!\"");
                    Console.ResetColor();

                    Enemy pingwin = new Enemy("Pingwin", 75, 20, 12);
                    CombatSystem.StartCombat(player, pingwin);

                    Console.WriteLine(" Złapałeś Pingwina w kanałach. Nie ma już dokąd uciec.");
                    pingwinZbadany = true;
                    capturedVillains.Add("Pingwin");
                    kanalZbadany = true;
                    Console.WriteLine("\nNaciśnij Enter, aby prztransportować pingwina na Komisariat...");
                    Console.ReadLine();
                    player.MoveTo(locations["Police station"]);
                    Console.Clear() ;
                    if (NigmaZbadany == true)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Pingwin (cały w błocie, z poderżniętym rękawem):");
                        Console.WriteLine("\"Ugh... po co tyle dramatyzmu, nietoperzu? Przecież mogłeś po prostu zapytać.\"");
                        Console.WriteLine();
                        Console.WriteLine("(kaszle, wypluwa coś na podłogę)");
                        Console.WriteLine();
                        Console.WriteLine("\"Kanały to było tylko chwilowe schronienie. Przez tego popaprańca – Jokera – wszystko się rozpieprzyło.\"");
                        Console.WriteLine("\"On myśli, że Gotham to jego teatrzyk... A my wszyscy jesteśmy jego klaunami.\"");
                        Console.WriteLine();
                        Console.WriteLine("\"Zrobiłem swoje. Przekazałem ładunek. Załatwione. I co? Potem nagle: bum! Ludzie mutują, a ja mam za to beknąć?\"");
                        Console.WriteLine();
                        Console.WriteLine("\"Jeśli chcesz znać prawdę – Joker planuje coś wielkiego. W Arkham. Tak, dobrze słyszysz – ZNOWU Arkham.\"");
                        Console.WriteLine();
                        Console.WriteLine("\"Teraz ty się tam wybierz, Nietoperzu. Ja zostaję tu... i chcę adwokata.\"");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine("\nNaciśnij Enter, aby kontynuować...");
                        Console.ReadLine();
                        Console.WriteLine("\n(Zalecane odwiedzenie Wayne Tower w celu odebrania upgarade'u statystyk po złapaniu Pingwina)");
                        Console.WriteLine();
                    }
                    if (NigmaZbadany != true)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Pingwin (z kajdankami na rękach):");
                        Console.WriteLine("\"Ej, ej! Nie jestem żadnym mózgiem tej operacji! Ja tylko udostępniałem lokal, rozumiesz? To wszystko przez tego pieprzonego klauna! Joker pociąga za wszystkie sznurki!\"");
                        Console.WriteLine();
                        Console.WriteLine("(krztusi się ze złości)");
                        Console.WriteLine();
                        Console.WriteLine("\"On tylko wykorzystał moje kontakty… Ja nie miałem pojęcia, co pakuję do tych walizek! Przysięgam!\"");
                        Console.WriteLine();
                        Console.WriteLine("(robi przerwę, patrząc ci prosto w oczy)");
                        Console.WriteLine();
                        Console.WriteLine("\"Ale... jeśli chcesz go złapać, to się pospiesz. Najnowsza dostawa Smylex-X ma trafić do jakiegoś przeklętego miejsca…\"");
                        Console.WriteLine("\"Do Starego Sierocińca. Tam znajdziesz odpowiedzi. I może... jego.\"");
                        Console.ResetColor();
                        Console.WriteLine("\n(Zalecane odwiedzenie Wayne Tower w celu odebrania upgarade'u statystyk po złapaniu Pingwina)");
                        Console.WriteLine();
                    }

                    }
                if(player.CurrentLocation.Name == "Canal Hideout" && !capturedVillains.Contains("Pingwin") && pingwinUciekł == true)
                {
                    Console.WriteLine("\nOdnajdz wiecej dowodów, aby tu wrócić i schwytac Pingwina...\n");
                }
                if (player.CurrentLocation.Name == "Canal Hideout" && capturedVillains.Contains("Pingwin")  )
                {
                    Console.WriteLine("Pingwin już siedzi w celi ") ;
                }
                if( player.CurrentLocation.Name == "Canal Hideout" && !capturedVillains.Contains("Pingwin"))
                {
                    Console.WriteLine("Obskurne kanały Gotham city");
                }
                

                if (player.CurrentLocation.Name == "Arkham Asylum")
                {
                    if (!capturedVillains.Contains("Pingwin") || !capturedVillains.Contains("Riddler"))
                    {
                        Console.WriteLine(" Drzwi do celi Jokera są zamknięte. Musisz najpierw schwytać Pingwina i Riddlera.");
                        
                    }
                    else if (!capturedVillains.Contains("Joker"))
                    {
                        Console.Clear();
                        Console.WriteLine(" Cele w Arkham są otwarte...");
                        Console.WriteLine("Nikogo nie ma w zasiegu wzroku...");
                        Console.WriteLine("Brak strażników i więzniów...");
                        Console.WriteLine("Nagle rozchodiz sie straszny dzwięk i pełno dymu...");
                        Console.Beep(600,700);
                        Console.WriteLine("Zostałeś uspiony gazem Jokera...");
                        Console.WriteLine("Dlatego...");
                        Console.WriteLine("Pojawiasz sie na specerniaku sam na sam ze złowieszczym klaunem");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Joker (siedząc na krześle, zakrwawiony uśmiech):");
                        Console.WriteLine("\"Ooo, mój ulubiony gość! Batman! Spóźniłeś się na własną imprezę...\"");
                        Console.WriteLine("\"Widzisz, wszyscy już dostali swój prezent – trochę chaosu, odrobina śmierci...\"");
                        Console.WriteLine("\"Ale Ty, ty zawsze musisz grać bohatera. Tak nudno!\"");
                        Console.ResetColor();

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Batman:");
                        Console.WriteLine("\"To się tu kończy, Joker. Nie zniszczysz więcej ludzi.\"");
                        Console.ResetColor();

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Joker:");
                        Console.WriteLine("\"Zawsze tak mówisz, Nietoperzu... A ja? Ja zawsze wracam. Ale dziś... to Ty zostaniesz w Arkham.\"");
                        Console.ResetColor();
                        Console.WriteLine("\nNaciśnij Enter, by kontynuować...");

                        Console.ReadLine() ;
                        Console.ForegroundColor= ConsoleColor.DarkMagenta;
                        var jokerNormal = new BossEnemy("Joker", 70, 25, 10, new List<string> {
                            "Joker: \"To wszystko, na co cię stać, Batsy?\"",
                            "Joker: \"Zatańczmy jak za dawnych czasów!\"",
                            "Joker: \"Czy to... pot? Nie mów, że się boisz!\"",
                            "Joker: \"\"Uśmiechnij się... to przecież zabawa!\""
                        });
                        Console.ResetColor();

                        CombatSystem.StartBossCombat(player, jokerNormal);

                        if (!player.IsAlive) Environment.Exit(0);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Joker (upadając na kolana):");
                        Console.WriteLine("\"Koniec? NIE! Nie tak kończy się mój spektakl!\"");
                        Console.WriteLine("*sięga po fiolkę Smylex-X i wstrzykuje sobie w szyję*");
                        Console.WriteLine("\"HAHAHA! Zaczynamy drugie AKT!\"");
                        Console.ResetColor();
                        
                        Console.WriteLine(" Joker mutuje pod wpływem Smylex-X!");
                        Console.WriteLine(" Jego ciało się zniekształca. Śmiech staje się głęboki i nieludzki...");
                        Console.ReadLine() ;
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        var jokerMutated = new BossEnemy("Zmutowany Joker", 150, 40, 20, new List<string> {
                            "Joker: \"Patrz na mnie! Jestem teraz prawdziwym potworem!\"",
                            "Joker: \"Mutacja pasuje mi, nie sądzisz?!\"",
                            "Joker: \"Uśmiechnij się, Nietoperzu... TO TWÓJ KONIEC!\"",
                            "Joker: \"Nie jestem już klaunem z Gotham... JESTEM BOGIEM ANARCHII!\""

                        });
                        Console.ResetColor();

                        CombatSystem.StartBossCombat(player, jokerMutated);

                        if (!player.IsAlive) Environment.Exit(0);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Mutant Joker (słaniając się na nogach):");
                        Console.WriteLine("\"Więc... tym razem to naprawdę koniec...?\"");
                        Console.WriteLine("\"Zawsze sądzisz, że wygrałeś. Ale chaos... chaos nie ma końca.\"");
                        Console.WriteLine("*Joker śmieje się słabo, po czym osuwa się na ziemię*");
                        Console.ResetColor();

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Batman:");
                        Console.WriteLine("\"Zawsze wracasz. Ale Gotham też zawsze się broni.\"");
                        Console.ResetColor();

                        Console.WriteLine(" Joker schwytany. Przewieziony do izolatki Arkham.");
                        Console.WriteLine(" BOSS FIGHT ZAKOŃCZONY!");




                        capturedVillains.Add("Joker");
                    }



                }
                                                                       





                Console.WriteLine("Dostępne przejścia:");
                    int index = 1;
                    foreach (var neighbor in player.CurrentLocation.Neighbors)
                    {
                        Console.WriteLine($"{index}. {neighbor.Key}");
                        index++;
                    }

                    Console.Write("\nWybierz, gdzie chcesz iść: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out int selectedIndex) && selectedIndex > 0 && selectedIndex <= player.CurrentLocation.Neighbors.Count)
                    {
                        string selectedLocation = new List<string>(player.CurrentLocation.Neighbors.Keys)[selectedIndex - 1];
                        player.MoveTo(player.CurrentLocation.Neighbors[selectedLocation]);
                    }
                    else
                    {
                        Console.WriteLine("Nieprawidłowy wybór. Naciśnij Enter, żeby spróbować jeszcze raz.");
                        Console.ReadLine();
                    }
                
            }
        }
    }
}



