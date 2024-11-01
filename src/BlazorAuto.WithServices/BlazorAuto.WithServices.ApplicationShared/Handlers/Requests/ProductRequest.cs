﻿namespace BlazorAuto.WithServices.ApplicationShared.Handlers.Requests
{
    public class CreateOrUpdateProductRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryTitle { get; set; }
    }
}
