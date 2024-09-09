﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LibraryApi.Data.Enum;

namespace LibraryApi.Models;

public class Book
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public BookGenre Genre { get; set; }
    [ForeignKey("Author")]
    public int AuthorId { get; set; }
    public Author Author { get; set; }
    public ICollection<Review> Reviews { get; set; }
}