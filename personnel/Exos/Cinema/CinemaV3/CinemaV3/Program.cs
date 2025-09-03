using Cinema;

List<Movie> frenchMovies = new List<Movie>() {
new Movie() { Title = "Le fabuleux destin d'Amélie Poulain", Genre = "Comédie", Rating = 8.3, Year = 2001, LanguageOptions = new string[] {"Français", "English"}, StreamingPlatforms = new string[] {"Netflix", "Hulu"} },
new Movie() { Title = "Intouchables", Genre = "Comédie", Rating = 8.5, Year = 2011, LanguageOptions = new string[] {"Français"}, StreamingPlatforms = new string[] {"Netflix", "Amazon"} },
new Movie() { Title = "The Matrix", Genre = "Science-Fiction", Rating = 8.7, Year = 1999, LanguageOptions = new string[] {"English", "Español"}, StreamingPlatforms = new string[] {"Hulu", "Amazon"} },
new Movie() { Title = "La Vie est belle", Genre = "Drame", Rating = 8.6, Year = 1946, LanguageOptions = new string[] {"Français", "Italiano"}, StreamingPlatforms = new string[] {"Netflix"} },
new Movie() { Title = "Gran Torino", Genre = "Drame", Rating = 8.2, Year = 2008, LanguageOptions = new string[] {"English"}, StreamingPlatforms = new string[] {"Hulu"} },
new Movie() { Title = "La Haine", Genre = "Drame", Rating = 8.1, Year = 1995, LanguageOptions = new string[] {"Français"}, StreamingPlatforms = new string[] {"Netflix"} },
new Movie() { Title = "Oldboy", Genre = "Thriller", Rating = 8.4, Year = 2003, LanguageOptions = new string[] {"Coréen", "English"}, StreamingPlatforms = new string[] {"Amazon"} }
};
List<Movie> filterMovieResponse = new List<Movie>();
Console.Write("Voulez vous activer le filtre de Comédie ou Drame o/n: ");
string un = Console.ReadLine();

if(un.ToLower() == "o")
{
    filterMovieResponse = frenchMovies.Where(y => y.Genre != "Comédie" && y.Genre != "Drame").ToList();
}

Console.Write("Voulez vous activer l'identification des films rating a 9 o/n: ");
string deux = Console.ReadLine();
                                                                                                                           
if (deux.ToLower() == "o" )                                                                                                
{                                                                                                                          
    if(filterMovieResponse == null)                                                                                   
    {                                                                                                                      
        filterMovieResponse = frenchMovies.Where(y => y.Rating < 9.0).ToList();                                            
                                                                                                                           
    }                                                                                                                      
    filterMovieResponse = filterMovieResponse.Where(y => y.Rating < 9.0).ToList();                                         
                                                                                                                           
}                                                                                                                          
                                                                                                                           
Console.Write("Voulez vous activer les films réalisés avant 2000 o/n: ");                                                  
string trois = Console.ReadLine();                                                                                         
                                                                                                                           
if (trois.ToLower() == "o")                                                                                                 
{                                                                                                                          
    if (filterMovieResponse == null)                                                                                                            
    {                                                                                                                                                
        filterMovieResponse = frenchMovies.Where(y => y.Year < 2000).ToList();                                                                       
                                                                                                                                                     
    }                                                                                                                                                
    filterMovieResponse = filterMovieResponse.Where(y => y.Year < 2000).ToList();                                                                    
                                                                                                                                                     
}                                                                                                                                                    
                                                                                                                                                     
Console.Write("Voulez vous activer les films qui n'ont pas de doublage en français o/n: ");                                                          
string quatre = Console.ReadLine();
if (quatre.ToLower() == "o")
{
    if (filterMovieResponse == null)
    {
        filterMovieResponse = frenchMovies.Where(y => !y.LanguageOptions.Any(l => l == "Français")).ToList();


        filterMovieResponse = filterMovieResponse.Where(y => !y.LanguageOptions.Any(l => l == "Français")).ToList();

    }
}

    Console.Write("Voulez vous activer lles films non présent sur netflix o/n: ");
    string cinq = Console.ReadLine();

    if (cinq.ToLower() == "o")
    {
        if (filterMovieResponse == null)
        {
            filterMovieResponse = frenchMovies.Where(y => !y.StreamingPlatforms.Any(l => l == "Netflix")).ToList();

        }
        filterMovieResponse = filterMovieResponse.Where(y => !y.StreamingPlatforms.Any(l => l == "Netflix")).ToList();

    }

    filterMovieResponse.ForEach(caca => Console.WriteLine(caca.Title));















