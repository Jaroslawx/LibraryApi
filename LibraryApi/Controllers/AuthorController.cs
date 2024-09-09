﻿using LibraryApi.Data;
using LibraryApi.Dtos.Author;
using LibraryApi.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers;

[Route("LibraryApi/author")]
[ApiController]
public class AuthorController (ApplicationDbContext context) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var authors = context.Authors.ToList()
            .Select(s => s.ToAuthorDto());

        return Ok(authors);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var author = context.Authors.Find(id);

        if (author == null)
        {
            return NotFound();
        }

        return Ok(author.ToAuthorDto());
    }
    
    [HttpPost]
    public IActionResult Create([FromBody] CreateAuthorRequestDto authorDto)
    {
        var authorModel = authorDto.ToAuthorFromCreateDto();
        context.Authors.Add(authorModel);
        context.SaveChanges();
        
        return CreatedAtAction(nameof(GetById), new { id = authorModel.Id }, authorModel.ToAuthorDto());
    }
}