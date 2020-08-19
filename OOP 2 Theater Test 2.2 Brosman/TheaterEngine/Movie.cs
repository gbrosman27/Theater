using System;
using System.Text.RegularExpressions;

namespace TheaterEngine
{
    /// <summary>
    /// The class which is used to represent a theater.
    /// </summary>
    public class Movie
    {
        /// <summary>
        /// The indicator of whether or not the movie is 3D.
        /// </summary>
        private bool is3d;

        /// <summary>
        /// The MPAA rating of the movie.
        /// </summary>
        private MovieRating rating;

        /// <summary>
        /// The runtime of the movie (in minutes).
        /// </summary>
        private int runtime;

        /// <summary>
        /// The title of the movie.
        /// </summary>
        private string title;

        /// <summary>
        /// Initializes a new instance of the Movie class.
        /// </summary>
        /// <param name="is3d">An indicator of whether or not the movie is 3D.</param>
        /// <param name="rating">The MPAA rating of the movie.</param>
        /// <param name="runtime">The runtime of the movie (in minutes).</param>
        /// <param name="title">The title of the movie.</param>
        public Movie(bool is3d, MovieRating rating, int runtime, string title)
        {
            this.is3d = is3d;
            this.rating = rating;
            this.runtime = runtime;
            this.title = title;
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not the movie is in 3D.
        /// </summary>
        public bool Is3d
        {
            get
            {
                return this.is3d;
            }

            set
            {
                this.is3d = value;
            }
        }

        /// <summary>
        /// Gets or sets the movie's rating.
        /// </summary>
        public MovieRating Rating
        {
            get
            {
                return this.rating;
            }

            set
            {
                this.rating = value;
            }
        }

        /// <summary>
        /// Gets or sets the length of the movie (in minutes).
        /// </summary>
        public int Runtime
        {
            get
            {
                return this.runtime;
            }

            set
            {
                if (this.runtime >= 1 && this.runtime <= 210)
                {
                    this.runtime = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("The movie runtime must be between one and 210 minutes.");
                }
            }
        }

        /// <summary>
        /// Gets or sets the movie's title.
        /// </summary>
        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                if (this.title.Length >= 1 && this.title.Length <= 100)
                {
                    this.title = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Movie Title Length", "The movie title length must be between 1 and 100 characters.");
                }
            }
        }

        /// <summary>
        /// Creates a string representation of a movie.
        /// </summary>
        /// <returns>The string.</returns>
        public override string ToString()
        {
            return this.title + " (" + this.rating + ", " + this.runtime + " mins)";
        }
    }
}