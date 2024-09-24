﻿namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

public class BlogPostAdminDto
{
    public string ApplicationUserName { get; set; } = string.Empty;
    public Guid Id { get; set; }

    public ApplicationUser? Author { get; set; }
    public List<BlogPostTag>? BlogPostTags { get; set; } = [];
    public Category? Category { get; set; }
    public List<Comment>? Comments { get; set; } = [];
    // DtoPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static BlogPostAdminDto FromBlogPost(BlogPost? blogPost)
    {
        if (blogPost == null)
        {
            return new BlogPostAdminDto();
        }

        return new BlogPostAdminDto
        {
            Id = blogPost.Id,

            Author = blogPost.Author,
            Category = blogPost.Category,
            // EntityToDtoPropertyPlaceholder
            // Title = blogPost.Title,
            // ToDoList = blogPost.ToDoList,
        };
    }

    public static BlogPost ToBlogPost(ApplicationUser applicationUser, BlogPostAdminDto blogPostAdminDto)
    {
        return new BlogPost
        {
            ApplicationUserUpdatedBy = applicationUser,
            Id = blogPostAdminDto.Id,

            Author = blogPostAdminDto.Author,
            Category = blogPostAdminDto.Category,
            // DtoToEntityPropertyPlaceholder
            // Title = blogPostAdminDto.Title,
            // ToDoList = blogPostAdminDto.ToDoList,
        };
    }
}
