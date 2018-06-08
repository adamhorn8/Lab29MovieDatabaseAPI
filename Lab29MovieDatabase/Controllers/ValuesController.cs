using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lab29MovieDatabase.Models;

namespace Lab29MovieDatabase.Controllers
{
    public class ValuesController : ApiController
    {
        public List<MovieList> GetMovies()
        {
            MoviesEntities db = new MoviesEntities();

            List<MovieList> Movies = db.MovieLists.ToList();

            return Movies;
        }

        public List<MovieList> GetMoviesByCategory(string id)
        {
            MoviesEntities db = new MoviesEntities();

            List<MovieList> Movies = (from p in db.MovieLists
                                  where p.Category.Contains(id)
                                  select p).ToList();

            return Movies;
        }

        public List<MovieList> GetRandomMovie()
        {
            MoviesEntities db = new MoviesEntities();

            Random rnd = new Random();
            int id = rnd.Next(1, 15);

            List<MovieList> Movies = (from p in db.MovieLists
                                         where p.ID == (id)
                                         select p).ToList();

            return Movies;
        }

        public MovieList GetRandomMovieByCategory(string id)
        {
            MoviesEntities db = new MoviesEntities();

            List<MovieList> Movies = (from p in db.MovieLists
                                      where p.Category.Contains(id)
                                      select p).ToList();

            Random rnd = new Random();
            int ran = rnd.Next(0, Movies.Count);



            MovieList data = Movies[ran];


            return data;
        }

        public List<MovieList> GetRandomMovies(int id)
        {
            int l = 0;
            Random rnd = new Random();
            List<MovieList> RandomMovies = new List<MovieList>();

            while (l < id)
            {

                MoviesEntities db = new MoviesEntities();

                int ran = rnd.Next(1, 15);

                MovieList Movie = (from p in db.MovieLists
                                          where p.ID == (ran)
                                          select p).Single();

                if (RandomMovies.Contains(Movie))
                {
                    l--;
                }
                else
                {
                    RandomMovies.Add(Movie);

                    l++;
                }
            }

            return RandomMovies;
        }

    }
}
