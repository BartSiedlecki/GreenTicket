using GreenTicket_WebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace GreenTicket_WebAPI.Services
{
    public class DataSeeder
    {
        private readonly GreenTicketDbContext _context;

        public DataSeeder(GreenTicketDbContext context)
        {
            _context = context;
        }

        // DELETE FROM [Seat]
        // DELETE FROM [Row]
        // DELETE FROM [EventPerformer]
        // DELETE FROM [Performer]
        // DELETE FROM [Event]
        // DELETE FROM [Section]
        // DELETE FROM [Venue]
        // DELETE FROM [EventSubCategory]
        // DELETE FROM [EventCategory]

        public void Seed()
        {
            if (_context.Database.CanConnect())
            {
                if (!_context.EventCategories.Any())
                {
                    var eventCategories = getCategories();
                    _context.EventCategories.AddRange(eventCategories);
                    _context.SaveChanges();
                }

                if (!_context.Performers.Any())
                {
                    var performers = getPerformers();
                    _context.Performers.AddRange(performers);
                    _context.SaveChanges();
                }

                if (!_context.Venues.Any())
                {
                    var venues = getVenues();
                    _context.Venues.AddRange(venues);
                    _context.SaveChanges();
                }

                if (!_context.Events.Any())
                {
                    var events = getEvents();
                    _context.Events.AddRange(events);
                    _context.SaveChanges();
                }
            }
        }

        private IEnumerable<Performer> getPerformers()
        {
            var performers = new List<Performer>()
            {
                new Performer() { Name = "Electric Callboy" },
                new Performer() { Name = "Sting" },
                new Performer() { Name = "Sanah" },
                new Performer() { Name = "Alpha Wolf" },
                new Performer() { Name = "King 810" },
                new Performer() { Name = "Ten56" },
                new Performer() { Name = "Xile" },
                new Performer() { Name = "Prof. Maciej Poliszewski" },
                new Performer() { Name = "Orion" },
                new Performer() { Name = "Zenon Martyniuk" },
                new Performer() { Name = "Kombi" },
                new Performer() { Name = "Zenek" },
                new Performer() { Name = "Wirujący Derwisze z bractwa Mawlawi" },
                new Performer() { Name = "Fisz" },
                new Performer() { Name = "Emade" },
                new Performer() { Name = "Liroy" },
                new Performer() { Name = "Donald Churchill" },
                new Performer() { Name = "Peter Yeldhman" },
                new Performer() { Name = "Sukhishvili" },
                new Performer() { Name = "Metro" },
                };
            return performers;
        }

        private IEnumerable<EventCategory> getCategories()
        {
            var categories = new List<EventCategory>()
            {
                new EventCategory()
                {
                    Title = "Concerts",
                    SubCategories = new List<EventSubCategory>() {
                        new EventSubCategory { Title = "Rock/Pop" },
                        new EventSubCategory { Title = "Hard/Heavy" },
                        new EventSubCategory { Title = "Classical music" },
                        new EventSubCategory { Title = "Electronic/Techno" },
                        new EventSubCategory { Title = "Disco/Dance" },
                        new EventSubCategory { Title = "Jazz" },
                        new EventSubCategory { Title = "Rap/Hip-Hop" },
                        new EventSubCategory { Title = "Others" }
                    }
                },
                new EventCategory()
                {
                    Title = "Culture",
                    SubCategories = new List<EventSubCategory>() {
                        new EventSubCategory { Title = "Theatre" },
                        new EventSubCategory { Title = "Ballet/Dance" },
                        new EventSubCategory { Title = "Musical" },
                        new EventSubCategory { Title = "Others" }
                    }
                },
                new EventCategory()
                {
                    Title = "Sport",
                    SubCategories = new List<EventSubCategory>() {
                        new EventSubCategory { Title = "Handball" },
                        new EventSubCategory { Title = "Football" },
                        new EventSubCategory { Title = "Vollayball" },
                        new EventSubCategory { Title = "Motor sports" },
                        new EventSubCategory { Title = "Bastekball" },
                        new EventSubCategory { Title = "Others" }
                    }
                },
                new EventCategory()
                {
                    Title = "Other",
                    SubCategories = new List<EventSubCategory>() {
                        new EventSubCategory { Title = "Family" },
                        new EventSubCategory { Title = "Other" }
                    }
                }


            };

            return categories;
        }

        private IEnumerable<Venue> getVenues()
        {
            var venues = new List<Venue>()
            {
                new Venue ()
                {
                    Name = "B90",
                    Description = "B90 to największy klub koncertowy w Trójmieście, " +
                    "zlokalizowany na terenie byłej Stoczni Gdańskiej, w scenerii historycznych dźwigów, " +
                    "pochylni i obiektów przemysłowych. 10 min. od Centrum Starego Miasta przestrzeń o powierzchni 1700 m, " +
                    "posiadająca niezależną antresolę. To symbiotyczna, alternatywna przestrzeń dla sztuki niezależnej, " +
                    "sytuująca się w pełni surowym klimacie. To industrialny magazyn, zlokalizowany w niebanalnym miejscu, " +
                    "wypełniony wszechstronną przestrzenią dla muzyki.",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "80-863",
                            City="Gdańsk",
                            Street = "Doki",
                            StreetNo = "1"
                        },
                    Capacity = 1200
                }
                ,
                new Venue ()
                {
                    Name = "Filharmonia im. Mieczysława Karłowicza w Szczecinie",
                    Description = "Bilety Filharmonii w Szczecinie pozwolą na spędzenie niezapomnianego czasu w otoczeniu najlepszej muzyki, " +
                    "która pozwoli zrelaksować się i oderwać na chwilę od codzienności. " +
                    "Koncerty Filharmonii Szczecin to propozycja doskonałej rozrywki na najwyższym poziomie, która na długo pozostanie w pamięci.",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "70-515",
                            City="Szczecin",
                            Street = "Małopolska",
                            StreetNo = "48"
                        },
                    Capacity = 950
                },
                new Venue ()
                {
                    Name = "Narodowe Forum Muzyki we Wrocławiu",
                    Description = "Narodowe Forum Muzyki im. Witolda Lutosławskiego to instytucja kultury miasta Wrocławia, " +
                    "współprowadzona przez Ministra Kultury i Dziedzictwa Narodowego, Gminę Wrocław, Województwo Dolnośląskie, " +
                    "zarejestrowana w Rejestrze Instytucji Kultury Gminy Wrocław. " +
                    "Instytucja jest operatorem nowoczesnego wielofunkcyjnego gmachu koncertowego we Wrocławiu.",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "50-071",
                            City="Wrocław",
                            Street = "plac Wolności",
                            StreetNo = "1"
                        },
                    Capacity = 1800
                },
                new Venue ()
                {
                    Name = "Parlament",
                    Description = "Klub Parlament to najbardziej rozpoznawalny klub w Trójmieście. " +
                    "Znajduje się przy ul. Świętego Ducha 2 w samym centrum Gdańska. Historia klubu sięga roku 2000, " +
                    "kiedy to rozpoczęła się przebudowa pomieszczeń dawnej stolarni Teatru Wybrzeże. " +
                    "Prace remontowe zakończyły się w listopadzie 2001 roku. " +
                    "To wtedy oficjalnie został otwarty największy i najnowocześniejszy klub muzyczny w Trójmieście.",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "80-834",
                            City="Gdańsk",
                            Street = "Świętego Ducha",
                            StreetNo = "2"
                        },
                    Capacity = 650
                },
                new Venue ()
                {
                    Name = "Filharmonia Łódzka",
                    Description = "Nagrodzona Fryderykiem 2020 Filharmonia Łódzka im. Artura Rubinsteina jest jedną z najstarszych w Polsce. " +
                    "Orkiestra Symfoniczna FŁ została odznaczona Złotym Medalem Zasłużony Kulturze - Gloria Artis.",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "90-135",
                            City="Łódź",
                            Street = "Prezydenta Gabriela Narutowicza",
                            StreetNo = "20/22"
                        },
                    Capacity = 658
                },
                new Venue ()
                {
                    Name = "Gdański Teatr Szekspirowski",
                    Description = "Gdański Teatr Szekspirowski jest jedynym teatrem szekspirowskim w Polsce. " +
                    "Powstał w miejscu, gdzie od początku XVII wieku funkcjonował budynek Szkoły Fechtunku – " +
                    "pierwszy publiczny teatr ówczesnej Rzeczypospolitej. " +
                    "Wyposażony w scenę typu elżbietańskiego i podobny do licznych teatrów angielskich epoki Elżbiety I, " +
                    "służył on zarówno do ćwiczeń i zawodów szermierczych, jak i do wystawiania przedstawień.",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "85-070",
                            City="Bydgoszcz",
                            Street = "Marszałka Ferdynanda Focha",
                            StreetNo = "5"
                        },
                    Capacity = 687
                },
                new Venue ()
                {
                    Name = "Stadion Narodowy (PGE Narodowy)",
                    Description = "PGE Narodowy (dawniej Stadion Narodowy w Warszawie) to najnowocześniejsza arena wielofunkcyjna i " +
                    "jeden z najnowocześniejszych tego typu obiektów w Europie. W 2013 roku stał się najpopularniejszym miejscem w Polsce, " +
                    "przyciągając 1 milion 300 tys. gości w ciągu 12 miesięcy. Arena jest największym stadionem w Polsce.",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "03-901",
                            City="Warszawa",
                            Street = "Al. Ks. J. Poniatowskiego",
                            StreetNo = "1"
                        },
                    Capacity = 58000
                },
                new Venue ()
                {
                    Name = "Atlas Arena",
                    Description = "Atlas Arena Łódź to jedna z większych hal widowiskowo-sportowych w Polsce, " +
                    "oddana do użytku w 2009 roku. Trybuny mogą pomieścić 10,4 tys. widzów, a na płycie można ustawić dodatkowo 3 tys. " +
                    "miejsc, do dyspozycji gości dostępnych jest 1500 miejsc postojowych, 4 ekrany multimedialne i 11 loży VIP-owskich (każda z tarasem).",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "94-020",
                            City="Łódź",
                            Street = "Al. ks. bp. Władysława Bandurskiego",
                            StreetNo = "7"
                        },
                    Capacity = 13806
                },
                new Venue ()
                {
                    Name = "Klub Hybrydy",
                    Description = "Jeden z najstarszych klubów studenckich w Polsce. „Hybrydy” działają z przerwami od końca lat 50. XX w. " +
                    "Przez wiele lat klub pełnił rolę centrum kultury studenckiej i matecznika artystycznego, z którego wyrosło wielu literatów, " +
                    "muzyków, twórców teatralnych i filmowych.",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "00-019",
                            City="Warszawa",
                            Street = "Złota",
                            StreetNo = "7/9"
                        },
                    Capacity = 400
                },
                new Venue ()
                {
                    Name = "TAURON Arena Kraków",
                    Description = "TAURON Arena Kraków to największa i najnowocześniejsza hala widowiskowo-sportowa w Polsce, " +
                    "mogąca pomieścić 22 000 osób, pozwala na organizację wydarzeń o różnym charakterze i skali. " +
                    "Wśród nich są wydarzenia sportowe i kulturalne: koncerty, festiwale, pokazy filmowe, musicale, pokazy cyrkowe, " +
                    "show na lodzie; gale, kongresy, bankiety, imprezy branżowe i plenerowe.",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "31-571",
                            City="Kraków",
                            Street = "Stanisława Lema",
                            StreetNo = "7"
                        },
                    Capacity = 13806
                },
                new Venue ()
                {
                    Name = "Progresja",
                    Description = "Klub Progresja Warszawa udostępnia artystom aż trzy niezależne sceny: Main Stage, " +
                    "Noise Stage i Progresja Cafe. Klub ma także wspaniale rozwinięte zaplecze barowe - " +
                    "szeroki wybór piw rzemieślniczych i innych alkoholi. Na scenie Progresji występowali między innymi: " +
                    "Behemoth, White Lies, Riverside, Imany, Mastodon, Billy Talent, Marka „Prezesa” Laskowskiego, Machine Gun Kelly, Coma, " +
                    "Chylińska i wielu innych znakomitych artystów.",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "01-258",
                            City="Warszawa",
                            Street = "Fort Wola",
                            StreetNo = "22"
                        },
                    Capacity = 2000
                },
                new Venue ()
                {
                    Name = "Arena Gliwice",
                    Description = "Arena Gliwice to obiekt halowy o przeznaczeniu widowiskowo-sportowym. " +
                    "To także jeden z najnowocześniejszych i największych obiektów tego rodzaju w Polsce. Na Śląsku nie ma sobie równych.",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "44-100",
                            City="Gliwice",
                            Street = "Akademicka",
                            StreetNo = "50"
                        },
                    Capacity = 13300
                },
                new Venue ()
                {
                    Name = "Klub Wytwórnia",
                    Description = "Łódzki klub muzyczny działający od 2007 roku, którego właścicielem jest Grupa Toya. " +
                    "Poza koncertami, w klubie organizowane są również spektakle filmowe oraz teatralne, wystawy sztuki, " +
                    "spotkania z artystami, imprezy zamknięte, bankiety czy różnego rodzaju festiwale",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "90-554",
                            City="Łódź",
                            Street = "Łąkowa",
                            StreetNo = "29"
                        },
                    Capacity = 1600
                },
                new Venue ()
                {
                    Name = "COS Torwar",
                    Description = "Dzięki dogodnej lokalizacji w centrum miasta Torwar to jedno z najlepszych miejsc do organizacji wielu imprez muzycznych. " +
                    "Występowali tutaj najwięksi polscy i światowi artyści, m.in. " +
                    "Jean Michel Jarre, Lenny Kravitz, The Prodigy, Hurts czy Placebo. " +
                    "Warto także wspomnieć o imprezach cyklicznych i trasach koncertowych takich jak Disney On Ice, " +
                    "koncerty Chóru Aleksandrowa, czy występy Moscow City Ballet.",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "00-449",
                            City="Warszawa",
                            Street = "Łazienkowska",
                            StreetNo = "6A"
                        },
                    Capacity = 4800
                },
                new Venue ()
                {
                    Name = "Palladium",
                    Description = "Klub Palladium to jeden z najpopularniejszych obiektów na kulturalno-rozrywkowej mapie stolicy Polski - Warszawy. " +
                    "Od początku swojego istnienia mieści się w samym centrum miasta, przy ul. Złotej 9. " +
                    "Obecnie w Klubie Palladium odbywają się rozmaite wydarzenia kulturalno-rozrywkowe – koncerty i spektakle teatralne.",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "00-019",
                            City="Warszawa",
                            Street = "Złota",
                            StreetNo = "9"
                        },
                    Capacity = 620
                },
                new Venue ()
                {
                    Name = "Scena",
                    Description = "Scena Sopot organizuje wydarzenia rozrywkowe i kulturalne. " +
                    "Obiekt ulokowany w zachwycającej scenerii sopockiej plaży, w pobliżu molo, " +
                    "jest znakomitym miejscem do zabawy przy dźwiękach muzyki na żywo. " +
                    "Odbywają się w nim koncerty, kabarety, ale też bankiety, szkolenia i imprezy firmowe.",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "81-729",
                            City="Sopot",
                            Street = "Al. Franciszka Mamuszki",
                            StreetNo = "2"
                        },
                    Capacity = 2000
                },
                new Venue ()
                {
                    Name = "Stary Maneż",
                    Description = "Stary Maneż to gdański klub muzyczny a zarazem dom kultury, uruchomiony w październiku 2015 roku. " +
                    "Obiekt, zajmujący m.in. tereny XIX-wiecznej ujeżdżalni kawalerii zwanej Czarnymi Huzarami, " +
                    "mieści się u zbiegu ulic Chrzanowskiego i Słowackiego. Stary Maneż Gdańsk jest miejscem niezwykle klimatycznym.",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "80-257",
                            City="Gdańsk",
                            Street = "Juliusza Słowackiego",
                            StreetNo = "23"
                        },
                    Capacity = 1490
                },
                new Venue ()
                {
                    Name = "Arena Toruń",
                    Description = "Arena Toruń to hala sportowa i widowiskowa mieszcząca się przy ulicy Generała Józefa Bema 73-89 w Toruniu. " +
                    "Hala została oficjalnie otwarta 10 sierpnia 2014 roku. " +
                    "Odbywają się tutaj przede wszystkim wydarzenia o charakterze sportowym, " +
                    "często jednak organizowane są tu również wydarzenia kulturalno-rozrywkowe, takie jak koncerty i spektakle.",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "87-100",
                            City="Toruń",
                            Street = "Generała Józefa Bema",
                            StreetNo = "73/89"
                        },
                    Capacity = 5780
                },
                new Venue ()
                {
                    Name = "Ergo Arena",
                    Description = "ERGO ARENA to hala widowiskowo – sportowa położona na granicy dwóch miast: Gdańska i Sopotu (plac Dwóch Miast 1). " +
                    "Obiekt, oddany do użytku w 2010 roku, może pomieścić ponad 11 000 widzów (miejsca siedzące). " +
                    "Duża powierzchnia ERGO ARENY pozwala na organizację imprez masowych, takich jak wydarzenia sportowe, " +
                    "koncerty, widowiska muzyczne i kulturalne, targi oraz konferencje.",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "80-344",
                            City="Gdańsk",
                            Street = "plac Dwóch Miast",
                            StreetNo = "1"
                        },
                    Capacity = 15000
                },
                new Venue ()
                {
                    Name = "Stadion Śląski",
                    Description = "Stadion Śląski mieści się przy ulicy Katowickiej 10 w Chorzowie. " +
                    "Stadion Śląski został ponownie otwarty 1 października 2017 roku. " +
                    "Modernizacja zakończyła się oddaniem do użytku obiektu spełniającego najwyższe wymogi stawiane zarówno stadionom piłkarskim, jak i stadionom lekkoatletycznym.",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "41-500",
                            City="Chorzów",
                            Street = "Katowicka",
                            StreetNo = "10"
                        },
                    Capacity = 15000
                }
                };

            return venues;
        }

        private IEnumerable<Event> getEvents()
        {
            var events = new List<Event>()
            {
                new Event()
                {
                    Name="Electric Callboy",
                    Description="Electric Callboy powrócą do nas z nowym albumem „Tekkno”, " +
                    "którego premierę zapowiedziano na 9 września 2022 roku nakładem Century Media Records.",
                    VenueId = getVenueId("Progresja"),
                    StartDateTime=new DateTime(2023,04,10,20,00,00),
                    EndDateTime=new DateTime(2023,04,10,23,30,00),
                    EventSubCategoryId= getEventSubcategoryId("Concerts", "Hard/Heavy"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Electric Callboy") }
                        },
                    Sections = new List<Section>()
                        {
                            new Section()
                            {
                                Name="General Admission",
                                Capacity=1700,
                                Price = 120m,
                                IsStanding = true
                            },
                            new Section()
                            {
                                Name="VIP",
                                Capacity=300,
                                Price=249m,
                                IsStanding = true
                            }
                        }
                },
                new Event()
                {
                    Name="Electric Callboy",
                    Description="Electric Callboy powrócą do nas z nowym albumem „Tekkno”, " +
                    "którego premierę zapowiedziano na 9 września 2022 roku nakładem Century Media Records.",
                    VenueId = getVenueId("Scena"),
                    StartDateTime=new DateTime(2023,04,12,19,30,00),
                    EndDateTime=new DateTime(2023,04,12,23,00,00),
                    EventSubCategoryId= getEventSubcategoryId("Concerts", "Hard/Heavy"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Electric Callboy") }
                        },
                    Sections = new List<Section>()
                        {
                            new Section()
                            {
                                Name="General Admission",
                                Capacity=1800,
                                Price = 120m,
                                IsStanding = true
                            },
                            new Section()
                            {
                                Name="VIP",
                                Capacity=200,
                                Price=249m,
                                IsStanding = true
                            }
                        }
                },
                new Event()
                {
                    Name="Electric Callboy",
                    Description="Electric Callboy powrócą do nas z nowym albumem „Tekkno”, " +
                    "którego premierę zapowiedziano na 9 września 2022 roku nakładem Century Media Records.",
                    VenueId = getVenueId("Narodowe Forum Muzyki we Wrocławiu"),
                    StartDateTime=new DateTime(2023,04,14,19,30,00),
                    EndDateTime=new DateTime(2023,04,14,23,00,00),
                    EventSubCategoryId= getEventSubcategoryId("Concerts", "Hard/Heavy"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Electric Callboy") }
                        },
                    Sections = new List<Section>()
                        {
                            new Section()
                            {
                                Name="Main hall",
                                Capacity=960,
                                Price = 120m,
                                Rows = new List<Row>()
                                {
                                    new Row() { Name="A", Seats = getSeats(60) },
                                    new Row() { Name="B", Seats = getSeats(60) },
                                    new Row() { Name="C", Seats = getSeats(60) },
                                    new Row() { Name="D", Seats = getSeats(60) },
                                    new Row() { Name="E", Seats = getSeats(60) },
                                    new Row() { Name="F", Seats = getSeats(60) },
                                    new Row() { Name="G", Seats = getSeats(60) },
                                    new Row() { Name="H", Seats = getSeats(60) },
                                    new Row() { Name="I", Seats = getSeats(60) },
                                    new Row() { Name="J", Seats = getSeats(60) },
                                    new Row() { Name="K", Seats = getSeats(60) },
                                    new Row() { Name="L", Seats = getSeats(60) },
                                    new Row() { Name="M", Seats = getSeats(60) }
                                }
                            },
                            new Section()
                            {
                                Name="VIP",
                                Capacity=180,
                                Price=249m,
                                Rows = new List<Row>()
                                {
                                    new Row() { Name="V1", Seats = getSeats(60) },
                                    new Row() { Name="V2", Seats = getSeats(60) },
                                    new Row() { Name="V3", Seats = getSeats(60) }
                                }
                            }
                        }
                },
                new Event()
                {
                    Name="Sting",
                    Description="Sting wraca do Polski! Znakomita trasa My Songs tym razem zawita 20 lipca 2022 roku do TAURON Areny Kraków. " +
                    "Sting bilety na koncert w Krakowie już w sprzedaży!",
                    VenueId = getVenueId("TAURON Arena Kraków"),
                    StartDateTime=new DateTime(2023,07,20,18,00,00),
                    EndDateTime=new DateTime(2023,07,20,23,00,00),
                    EventSubCategoryId= getEventSubcategoryId("Concerts", "Rock/Pop"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Sting") }
                        },
                    Sections = new List<Section>()
                        {
                            new Section()
                            {
                                Name="General Admission",
                                Capacity=5000,
                                Price = 249m,
                                IsStanding = true
                            },
                            new Section()
                            {
                                Name="Golden circle",
                                Capacity=1000,
                                Price=349m,
                                IsStanding = true
                            },
                            new Section()
                            {
                                Name="Golden circle Early Entry",
                                Capacity=500,
                                Price=499m,
                                IsStanding = true
                            },
                            getSeatingSection("A1",299m, 20, 14),
                            getSeatingSection("A2",299m, 20, 14),
                            getSeatingSection("A3",249m, 20, 14),
                            getSeatingSection("A4",249m, 20, 14),
                            getSeatingSection("A5",249m, 20, 14),
                            getSeatingSection("A6",249m, 20, 14),
                            getSeatingSection("A7",249m, 20, 14),
                            getSeatingSection("A8",249m, 20, 14),
                            getSeatingSection("A9",299m, 20, 14),
                            getSeatingSection("A10",299m, 20, 14),
                            getSeatingSection("A11",249m, 20, 14),
                            getSeatingSection("A12",249m, 20, 14),
                            getSeatingSection("A13",249m, 20, 14)
                        } 
                },
                new Event()
                {
                    Name="Sting",
                    Description="Sting wraca do Polski! Znakomita trasa My Songs tym razem zawita 20 lipca 2022 roku do TAURON Areny Kraków. " +
                    "Sting bilety na koncert w Krakowie już w sprzedaży!",
                    VenueId = getVenueId("Atlas Arena"),
                    StartDateTime=new DateTime(2023,07,22,18,00,00),
                    EndDateTime=new DateTime(2023,07,22,23,00,00),
                    EventSubCategoryId= getEventSubcategoryId("Concerts", "Rock/Pop"),
                     EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Sting") }
                        },
                    Sections = new List<Section>()
                        {
                            new Section()
                            {
                                Name="General Admission",
                                Capacity=4500,
                                Price = 279m,
                                IsStanding = true
                            },
                            new Section()
                            {
                                Name="Golden circle",
                                Capacity=1500,
                                Price=369m,
                                IsStanding = true
                            },
                            new Section()
                            {
                                Name="Golden circle Early Entry",
                                Capacity=500,
                                Price=519m,
                                IsStanding = true
                            },
                            getSeatingSection("A",249m, 20, 14),
                            getSeatingSection("B",249m, 20, 14),
                            getSeatingSection("C",249m, 20, 14),
                            getSeatingSection("D",249m, 20, 14),
                            getSeatingSection("E",299m, 20, 14),
                            getSeatingSection("F",299m, 20, 14),
                            getSeatingSection("O",299m, 20, 14),
                            getSeatingSection("P",299m, 20, 14),
                            getSeatingSection("R",249m, 20, 14),
                            getSeatingSection("S",249m, 20, 14),
                            getSeatingSection("T",249m, 20, 14),
                            getSeatingSection("U",249m, 20, 14),

                        }
                },
                new Event()
                {
                    Name="Sanah",
                    Description="Po wyprzedanych trasach koncertowych Uczta Tour ’22 oraz BANKIET, " +
                    "Sanah realizuje swoje marzenie - ogłasza Ucztę nad Ucztami! Artystka wystąpi 15 sierpnia na Stadionie Śląskim oraz " +
                    "8 września na Polsat Plus Arenie w Gdańsku w 2023 roku.",
                    VenueId = getVenueId("Atlas Arena"),
                    StartDateTime=new DateTime(2023,08,17,18,00,00),
                    EndDateTime=new DateTime(2023,08,17,23,00,00),
                    EventSubCategoryId= getEventSubcategoryId("Concerts", "Rock/Pop"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Sanah") }
                        },
                    Sections = new List<Section>()
                        {
                            new Section()
                            {
                                Name="General Admission",
                                Capacity=9000,
                                Price = 199m,
                                IsStanding = true
                            },
                            new Section()
                            {
                                Name="Golden circle Early Entry",
                                Capacity=2000,
                                Price=399m,
                                IsStanding = true
                            },
                            getSeatingSection("A",149m, 20, 14),
                            getSeatingSection("B",149m, 20, 14),
                            getSeatingSection("C",149m, 20, 14),
                            getSeatingSection("D",149m, 20, 14),
                            getSeatingSection("E",199m, 20, 14),
                            getSeatingSection("F",199m, 20, 14),
                            getSeatingSection("O",199m, 20, 14),
                            getSeatingSection("P",199m, 20, 14),
                            getSeatingSection("R",149m, 20, 14),
                            getSeatingSection("S",149m, 20, 14),
                            getSeatingSection("T",149m, 20, 14),
                            getSeatingSection("U",149m, 20, 14),
                        }
                },
                new Event()
                {
                    Name="Sanah",
                    Description="Po wyprzedanych trasach koncertowych Uczta Tour ’22 oraz BANKIET, Sanah realizuje swoje marzenie - " +
                    "ogłasza Ucztę nad Ucztami! Artystka wystąpi 15 sierpnia na Stadionie Śląskim oraz 8 września na Polsat Plus Arenie w Gdańsku w 2023 roku.",
                    VenueId = getVenueId("TAURON Arena Kraków"),
                    StartDateTime=new DateTime(2023,08,22,18,00,00),
                    EndDateTime=new DateTime(2023,08,22,23,00,00),
                    EventSubCategoryId= getEventSubcategoryId("Concerts", "Rock/Pop"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Sanah") }
                        },
                    Sections = new List<Section>()
                        {
                            new Section()
                            {
                                Name="General Admission",
                                Capacity=9000,
                                Price = 189m,
                                IsStanding = true
                            },
                            new Section()
                            {
                                Name="Golden circle Early Entry",
                                Capacity=2000,
                                Price=389m,
                                IsStanding = true
                            },
                            getSeatingSection("A1",199m, 20, 14),
                            getSeatingSection("A2",199m, 20, 14),
                            getSeatingSection("A3",149m, 20, 14),
                            getSeatingSection("A4",149m, 20, 14),
                            getSeatingSection("A5",149m, 20, 14),
                            getSeatingSection("A6",149m, 20, 14),
                            getSeatingSection("A7",149m, 20, 14),
                            getSeatingSection("A8",149m, 20, 14),
                            getSeatingSection("A9",199m, 20, 14),
                            getSeatingSection("A10",199m, 20, 14),
                            getSeatingSection("A11",149m, 20, 14),
                            getSeatingSection("A12",149m, 20, 14),
                            getSeatingSection("A13",149m, 20, 14)
                        }
                },
                new Event()
                {
                    Name="Alpha Wolf + King 810, Ten56, Xile",
                    Description="THE STEPPIN' over roaches tour 2023",
                    VenueId = getVenueId("Klub Wytwórnia"),
                    StartDateTime=new DateTime(2023,09,24,20,00,00),
                    EndDateTime=new DateTime(2023,09,24,23,00,00),
                    EventSubCategoryId= getEventSubcategoryId("Concerts", "Hard/Heavy"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Alpha Wolf") },
                            new EventPerformer() { PerformerId = getPerformerId("King 810") },
                            new EventPerformer() { PerformerId = getPerformerId("Ten56") },
                            new EventPerformer() { PerformerId = getPerformerId("Xile") },
                        },
                    Sections = new List<Section>()
                        {
                            new Section()
                            {
                                Name="General Admission",
                                Capacity=1600,
                                Price = 99m,
                                IsStanding = true
                            },
                            getSeatingSection("1-01",89m, 20, 14),
                            getSeatingSection("1-20",89m, 20, 14),
                            getSeatingSection("1-19",89m, 20, 14),
                            getSeatingSection("1-18",89m, 20, 14),
                            getSeatingSection("1-17",89m, 20, 14),
                            getSeatingSection("1-16",89m, 20, 14),
                            getSeatingSection("1-15",89m, 20, 14),
                            getSeatingSection("1-14",89m, 20, 14),
                            getSeatingSection("1-13",89m, 20, 14),
                            getSeatingSection("1-12",89m, 20, 14),
                            getSeatingSection("1-11",89m, 20, 14),
                            getSeatingSection("1-10",89m, 20, 14),
                            getSeatingSection("2-01",69m, 2, 12),
                            getSeatingSection("2-02",69m, 2, 12),
                            getSeatingSection("2-03",69m, 2, 12),
                            getSeatingSection("2-04",69m, 2, 12),
                            getSeatingSection("3-01",69m, 2, 12),
                            getSeatingSection("3-24",69m, 2, 12),
                            getSeatingSection("3-23",69m, 2, 12),
                            getSeatingSection("3-22",69m, 2, 12),
                            getSeatingSection("3-21",69m, 2, 12),
                            getSeatingSection("3-20",69m, 2, 12),
                            getSeatingSection("3-19",69m, 2, 12),
                            getSeatingSection("3-18",69m, 2, 12),
                            getSeatingSection("3-17",69m, 2, 12),
                            getSeatingSection("3-16",69m, 2, 12),
                            getSeatingSection("3-15",69m, 2, 12),
                            getSeatingSection("3-14",69m, 2, 12),
                            getSeatingSection("3-13",69m, 2, 12),
                            getSeatingSection("3-12",69m, 2, 12),
                        }
                },
                new Event()
                {
                    Name="Sylwester z Chopinem",
                    Description="Czwarta edycja Sylwestra z Chopinem. Zakończ 2023 rok wraz z utworami jednego z najwybitniejszych polskich kompozytorów.",
                    VenueId = getVenueId("Gdański Teatr Szekspirowski"),
                    StartDateTime=new DateTime(2023,12,31,20,00,00),
                    EndDateTime=new DateTime(2024,01,01,05,00,00),
                    EventSubCategoryId= getEventSubcategoryId("Concerts", "Classical music"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Prof. Maciej Poliszewski") }
                        },
                    Sections = new List<Section>()
                        {
                            getSeatingSection("Aula",499m, 20, 15)
                        }
                },
                new Event()
                {
                    Name="Metallica symfonicznie",
                    Description="W roku 2023 na kolejne koncerty powróci do Polski wyjątkowy projekt – " +
                    "pod szyldem “Metallica symfonicznie” wystąpi jeden z najlepszych coverbandów Metallica na świecie. " +
                    "W skład projektu wchodzi czteroosobowy zespół oraz orkiestra symfoniczna ‘Orion’.",
                    VenueId = getVenueId("Filharmonia im. Mieczysława Karłowicza w Szczecinie"),
                    StartDateTime=new DateTime(2023,06,16,20,00,00),
                    EndDateTime=new DateTime(2023,06,16,23,00,00),
                    EventSubCategoryId= getEventSubcategoryId("Concerts", "Classical music"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Orion") }
                        },
                    Sections = new List<Section>()
                        {
                            getSeatingSection("Sala główna", 299m, 30, 10)
                        }
                },
                new Event()
                {
                    Name="Metallica symfonicznie",
                    Description="W roku 2023 na kolejne koncerty powróci do Polski wyjątkowy projekt – " +
                    "pod szyldem “Metallica symfonicznie” wystąpi jeden z najlepszych coverbandów Metallica na świecie. " +
                    "W skład projektu wchodzi czteroosobowy zespół oraz orkiestra symfoniczna ‘Orion’.",
                    VenueId = getVenueId("Filharmonia Łódzka"),
                    StartDateTime=new DateTime(2023,06,22,20,00,00),
                    EndDateTime=new DateTime(2023,06,22,23,00,00),
                    EventSubCategoryId= getEventSubcategoryId("Concerts", "Classical music"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Orion") }
                        },
                    Sections = new List<Section>()
                        {
                            getSeatingSection("Sala główna", 299m, 20, 15)
                        }
                },
                new Event()
                {
                    Name="Zenon Martyniuk",
                    Description="Jest jednym z najpopularniejszych artystów polskich. " +
                    "Do jego najbardziej znanych utworów należą m.in. „Gwiazda”, „Królowa nocy”, " +
                    "„Pragnienie miłości”, „Przekorny los” czy „Sonet dla miłości”, który zadedykował swojej żonie.",
                    VenueId = getVenueId("Arena Gliwice"),
                    StartDateTime=new DateTime(2023,07,07,17,30,00),
                    EndDateTime=new DateTime(2023,07,07,22,30,00),
                    EventSubCategoryId= getEventSubcategoryId("Concerts", "Disco/Dance"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Zenon Martyniuk") }
                        },
                    Sections = new List<Section>()
                        {
                            new Section()
                            {
                                Name="General Admission",
                                Capacity=4000,
                                Price = 149m,
                                IsStanding = true,
                            },
                            new Section()
                            {
                                Name="Golden circle",
                                Capacity=2000,
                                Price=249m,
                                IsStanding = true,
                            }
                        }
                },
                new Event()
                {
                    Name="Gala Disco vol. 8",
                    Description="Największa impreza disco w regionie powraca! " +
                    "Topowi wykonawcy, wyjątkowa oprawa sceniczna i najświeższe hity polskiej muzyki tanecznej- " +
                    "wybuchowa mieszanka gwarantująca niezapomnianą zabawę!",
                    VenueId = getVenueId("COS Torwar"),
                    StartDateTime=new DateTime(2023,08,17,18,30,00),
                    EndDateTime=new DateTime(2023,08,17,23,30,00),
                    EventSubCategoryId= getEventSubcategoryId("Concerts", "Disco/Dance"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Kombi") },
                            new EventPerformer() { PerformerId = getPerformerId("Zenek") }
                        },
                    Sections = new List<Section>()
                        {
                            new Section()
                            {
                                Name="General Admission",
                                Capacity=7000,
                                Price = 89m
                            }
                        }
                },
                new Event()
                {
                    Name="Ethno Jazz Festival: Wirujący Derwisze",
                    Description="Ethno Jazz Festival ma zaszczyt po raz kolejny zaprosić na niezwykły mistyczny spektakl WIRUJĄCYCH DERWISZY z DAMASZKU. " +
                    "Występ pochodzących z Syrii Wirujących Derwiszy z bractwa Mawlawi, " +
                    "z gościnnym udziałem wybitnego koranicznego śpiewaka Noureddine Khourchida.",
                    VenueId = getVenueId("Parlament"),
                    StartDateTime=new DateTime(2023,10,24,18,30,00),
                    EndDateTime=new DateTime(2023,10,24,23,30,00),
                    EventSubCategoryId= getEventSubcategoryId("Concerts", "Jazz"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Wirujący Derwisze z bractwa Mawlawi") }
                        },
                    Sections = new List<Section>()
                        {
                            new Section()
                            {
                                Name="General Admission",
                                Capacity=450,
                                Price = 49m
                            }
                        }
                },
                new Event()
                {
                    Name="Fisz Emade Tworzywo",
                    Description="FISZ EMADE TWORZYWO to jeden z najważniejszych zespołów na polskim rynku fonograficznym. " +
                    "Od 2001 roku wydali 10 płyt utrzymanych w stylistyce około hiphopowej. " +
                    "Jako pierwsi na tak wysokim poziomie wprowadzili w polskim hiphopie miękkie brzmienia.",
                    VenueId = getVenueId("Klub Hybrydy"),
                    StartDateTime=new DateTime(2023,11,06,18,30,00),
                    EndDateTime=new DateTime(2023,11,06,22,30,00),
                    EventSubCategoryId= getEventSubcategoryId("Concerts", "Rap/Hip-Hop"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Fisz") },
                            new EventPerformer() { PerformerId = getPerformerId("Emade") }
                        },
                    Sections = new List<Section>()
                        {
                            new Section()
                            {
                                Name="General Admission",
                                Capacity=350,
                                Price = 99m
                            }
                        }
                },
                new Event()
                {
                    Name="The Legend – Powrót Legendy",
                    Description="Pierwsza edycja festiwalu muzycznego, który zabiera widzów w sentymentalną podróż po historii muzyki. " +
                    "Podczas pierwszej odsłony będziemy świadkami powrotu na scenę prekursora polskiej sceny hip-hopowej, autora legendarnych hitów - LIROYA.",
                    VenueId = getVenueId("Palladium"),
                    StartDateTime=new DateTime(2023,05,05,20,00,00),
                    EndDateTime=new DateTime(2023,05,05,23,30,00),
                    EventSubCategoryId= getEventSubcategoryId("Concerts", "Rap/Hip-Hop"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Liroy") }
                        },
                    Sections = new List<Section>()
                        {
                            new Section()
                            {
                                Name="General Admission",
                                Capacity=250,
                                Price = 109m
                            }
                        }
                },
                new Event()
                {
                    Name="Przekręt (nie)doskonały",
                    Description="Polska prapremiera błyskotliwej komedii mistrzów gatunku - Donalda Churchilla i Petera Yeldhmana. " +
                    "Churchill znany jest polskim widzom z takich hitów jak “Dekorator” czy “Chwile słabości” - " +
                    "obydwie sztuki w reżyserii Andrzeja Rozhina cieszyły się olbrzymim powodzeniem.",
                    VenueId = getVenueId("Gdański Teatr Szekspirowski"),
                    StartDateTime=new DateTime(2023,06,06,20,00,00),
                    EndDateTime=new DateTime(2023,06,06,23,30,00),
                    EventSubCategoryId= getEventSubcategoryId("Culture", "Theatre"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Donald Churchill") },
                            new EventPerformer() { PerformerId = getPerformerId("Peter Yeldhman") },
                        },
                    Sections = new List<Section>()
                        {
                            getSeatingSection("Aula",399m, 20, 15)
                        }
                },
                new Event()
                {
                    Name="Przekręt (nie)doskonały",
                    Description="Polska prapremiera błyskotliwej komedii mistrzów gatunku - Donalda Churchilla i Petera Yeldhmana. " +
                    "Churchill znany jest polskim widzom z takich hitów jak “Dekorator” czy “Chwile słabości” - " +
                    "obydwie sztuki w reżyserii Andrzeja Rozhina cieszyły się olbrzymim powodzeniem.",
                    VenueId = getVenueId("Gdański Teatr Szekspirowski"),
                    StartDateTime=new DateTime(2023,06,08,20,00,00),
                    EndDateTime=new DateTime(2023,06,08,23,30,00),
                    EventSubCategoryId= getEventSubcategoryId("Culture", "Theatre"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Donald Churchill") },
                            new EventPerformer() { PerformerId = getPerformerId("Peter Yeldhman") }
                        },
                    Sections = new List<Section>()
                        {
                            getSeatingSection("Aula",399m, 20, 15)
                        }
                },
                new Event()
                {
                    Name="Narodowy Balet Gruzji - Sukhishvili",
                    Description="Ich występ obejrzało ponad 90 mln widzów. Każdego roku czekają na nich w różnych krajach świata. " +
                    "Nazywają ich HURAGANEM NA SCENIE, DUCHEM WIDOWISKA, UNIKALNYM FENOMENEM, ÓSMYM CUDEM ŚWIATA!",
                    VenueId = getVenueId("Narodowe Forum Muzyki we Wrocławiu"),
                    StartDateTime=new DateTime(2023,07,25,20,00,00),
                    EndDateTime=new DateTime(2023,07,25,23,30,00),
                    EventSubCategoryId= getEventSubcategoryId("Culture", "Ballet/Dance"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Sukhishvili") }
                        },
                    Sections = new List<Section>()
                        {
                            new Section()
                            {
                                Name="Main hall",
                                Capacity=960,
                                Price = 79m,
                                Rows = new List<Row>()
                                {
                                    new Row() { Name="A", Seats = getSeats(60) },
                                    new Row() { Name="B", Seats = getSeats(60) },
                                    new Row() { Name="C", Seats = getSeats(60) },
                                    new Row() { Name="D", Seats = getSeats(60) },
                                    new Row() { Name="E", Seats = getSeats(60) },
                                    new Row() { Name="F", Seats = getSeats(60) },
                                    new Row() { Name="G", Seats = getSeats(60) },
                                    new Row() { Name="H", Seats = getSeats(60) },
                                    new Row() { Name="I", Seats = getSeats(60) },
                                    new Row() { Name="J", Seats = getSeats(60) },
                                    new Row() { Name="K", Seats = getSeats(60) },
                                    new Row() { Name="L", Seats = getSeats(60) },
                                    new Row() { Name="M", Seats = getSeats(60) }
                                }
                            },
                            new Section()
                            {
                                Name="VIP",
                                Capacity=180,
                                Price=249m,
                                Rows = new List<Row>()
                                {
                                    new Row() { Name="V1", Seats = getSeats(60) },
                                    new Row() { Name="V2", Seats = getSeats(60) },
                                    new Row() { Name="V3", Seats = getSeats(60) }
                                }
                            }
                        }
                },
                new Event()
                {
                    Name="Musical METRO",
                    Description="Grupa młodych wykonawców opowiada o swoich marzeniach, a każda wyśpiewana nuta, każdy wytańczony takt jest tych marzeń spełnieniem. " +
                    "Widzimy więc na scenie pasję i entuzjazm, taniec i śpiew jakiego nie znał polski teatr.",
                    VenueId = getVenueId("Filharmonia im. Mieczysława Karłowicza w Szczecinie"),
                    StartDateTime=new DateTime(2023,10,10,20,00,00),
                    EndDateTime=new DateTime(2023,10,10,22,30,00),
                    EventSubCategoryId= getEventSubcategoryId("Culture", "Musical"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Metro") }
                        },
                    Sections = new List<Section>()
                        {
                            getSeatingSection("Patio",99m, 22, 16)
                        }
                }
            };
            return events;
        }

        private int getVenueId(string venueName)
        {
            var venue = _context
                .Venues
                .AsNoTracking()
                .Select(v => new { v.Id, v.Name })
                .FirstOrDefault(v => v.Name == venueName);

            if (venue is null)
                throw new Exception($"Venue '{venueName}' not found");

            return venue.Id;
        }

        private int getEventSubcategoryId(string categoryName, string subCategoryName)
        {
            var subCategory = _context
                .EventSubCategories
                .Include(e => e.Category)
                .AsNoTracking()
                .FirstOrDefault(v => v.Category.Title == categoryName && v.Title == subCategoryName);

            if (subCategory is null)
                throw new Exception($"Subcategory '{subCategoryName}' in category '{categoryName}' not found");

            return subCategory.Id;
        }

        private int getPerformerId(string performerName)
        {
            var performer = _context
                .Performers
                .AsNoTracking()
                .Select(v => new { v.Id, v.Name })
                .FirstOrDefault(v => v.Name == performerName);

            if (performer is null)
                throw new Exception($"Performer '{performerName}' not found");

            return performer.Id;
        }

        private List<Row> getNumericRowsWithSeats(int noOfRows, int noOfSeatsInRow, int sectionId)
        {
            var rows = new List<Row>();
            for (int i = 1; i <= noOfRows; i++)
            {
                var seats = new List<Seat>();
                for (int j = 1; j < noOfSeatsInRow; j++)
                {
                    var seat = new Seat() { Number = j };
                    seats.Add(seat);
                }

                var newRow = new Row()
                {
                    SectionId= sectionId,
                    Name = i.ToString(),
                    Seats = seats
                };
            }
            return rows;
        }

        private List<Seat> getSeats(int noOfSeats)
        {
            
            var seats = new List<Seat>();
            for (int j = 1; j < noOfSeats; j++)
            {
                var seat = new Seat() { Number = j };
                seats.Add(seat);
            }

            return seats;
        }

        private Section getSeatingSection(string name, decimal price, int noOfRows, int noOfSeatsInRow)
        {
            var rows = new List<Row>();
            int sumOfPlaces = 0;

            for (int i = 0; i < noOfRows; i++)
            {
                var newRow = new Row() { Name = i.ToString(), Seats = getSeats(noOfSeatsInRow) };
                sumOfPlaces += noOfSeatsInRow;
                rows.Add(newRow);
            }

            return new Section()
            {
                Name = name,
                Capacity = sumOfPlaces,
                Price = price,
                Rows = rows
            };
        }
    }
}
