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


List<Movie> filterMovie1 = frenchMovies.Where(y => y.Genre != "Comédie" && y.Genre != "Drame").ToList();
filterMovie1.ForEach(movie => Console.WriteLine(movie.Title));

Console.WriteLine("---");
List<Movie> filterMovie2 = frenchMovies.Where(y => y.Rating < 7.0).ToList();

filterMovie2.ForEach(movie =>Console.WriteLine(movie.Title));
Console.WriteLine("---");


List<Movie> filterMovie3 = frenchMovies.Where(y => y.Year < 2000).ToList();
filterMovie3.ForEach(movie => Console.WriteLine(movie.Title));
Console.WriteLine("---");

List<Movie> filterMovie4 = frenchMovies.Where(y => !y.LanguageOptions.Any(l => l == "Français")).ToList();

filterMovie4.ForEach(movie => Console.WriteLine(movie.Title));
Console.WriteLine("---");


List<Movie> filterMovie5 = frenchMovies.Where(y => !y.StreamingPlatforms.Any(l => l == "Netflix")).ToList();
filterMovie5.ForEach(movie => Console.WriteLine(movie.Title));
Console.WriteLine("---");

List<Movie> filterMovieAll = frenchMovies.Where(y => !y.StreamingPlatforms.Any(l => l == "Netflix"))
    .Where(y => y.Genre != "Comédie" && y.Genre != "Drame")
    .Where(y => y.Rating < 7.0)
    .Where(y => y.Year < 2000)
    .Where(y => !y.LanguageOptions.Any(l => l == "Français"))
    .ToList();

filterMovieAll.ForEach(movie => Console.WriteLine(movie.Title));