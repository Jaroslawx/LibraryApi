﻿using LibraryApi.Dtos.Review;
using LibraryApi.Models;

namespace LibraryApi.Mappers;

public static class ReviewMappers
{
    public static ReviewDto ToReviewDto(this Review review)
    {
        return new ReviewDto
        {
            Id = review.Id,
            BookId = review.BookId,
            Rating = review.Rating,
            Comment = review.Comment
        };
    }
}