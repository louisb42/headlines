using Headline.Common.Models;

using Microsoft.EntityFrameworkCore;

namespace Headline.API.Helpers
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<HeadlineModel>().HasData(
                new HeadlineModel
                {
                    Id = 1,
                    Banner = "Before you marry a person, you should first make them use a computer with slow Internet to see who they really are.",
                    BackgroundColour = "#c0c0c0",
                    ForegroundColour = "#000000",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c2/Will_Ferrell_2012.jpg/330px-Will_Ferrell_2012.jpg",
                    Active = true
                });
            _ = modelBuilder.Entity<HeadlineModel>().HasData(
                new HeadlineModel
                {
                    Id = 2,
                    Banner = "I’m not insane. My mother had me tested.",
                    BackgroundColour = "#000000",
                    ForegroundColour = "#ffffff",
                    ImageUrl = "https://www.magicalquote.com/wp-content/uploads/2015/03/Sheldon-Cooper.jpg",
                    Active = true
                });
            _ = modelBuilder.Entity<HeadlineModel>().HasData(
                new HeadlineModel
                {
                    Id = 3,
                    Banner = "Everything you read on the internet is true.",
                    BackgroundColour = "#ffffff",
                    ForegroundColour = "#000000",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ab/Abraham_Lincoln_O-77_matte_collodion_print.jpg/330px-Abraham_Lincoln_O-77_matte_collodion_print.jpg",
                    Active = true
                });
            _ = modelBuilder.Entity<HeadlineModel>().HasData(
                new HeadlineModel
                {
                    Id = 4,
                    Banner = "Insomnia sharpens your math skills because you spend all night calculating how much sleep you’ll get if you’re able to ‘fall asleep right now.",
                    BackgroundColour = "#aa0000",
                    ForegroundColour = "#000000",
                    Active = true
                });
            _ = modelBuilder.Entity<HeadlineModel>().HasData(
                new HeadlineModel
                {
                    Id = 5,
                    Banner = "It is the time you have wasted for your rose that makes your rose so important.",
                    BackgroundColour = "#00aa00",
                    ForegroundColour = "#000000",
                    ImageUrl = "https://idsb.tmgrup.com.tr/ly/uploads/images/2020/07/06/thumbs/800x531/44741.jpg?v=1594038512",
                    Active = true
                });
            _ = modelBuilder.Entity<HeadlineModel>().HasData(
                new HeadlineModel
                {
                    Id = 6,
                    Banner = "A day without sunshine is like night.",
                    BackgroundColour = "#00aa00",
                    ForegroundColour = "#000000",
                    Active = true
                });
            _ = modelBuilder.Entity<HeadlineModel>().HasData(
                new HeadlineModel
                {
                    Id = 7,
                    Banner = "He’s the hero Gotham deserves, but not the one it needs right now. So we’ll hunt him...Because he can take it...Because he’s not our hero. He’s a silent guardian, a watchful protector. A dark knight.",
                    BackgroundColour = "#00aa00",
                    ForegroundColour = "#000000",
                    Active = false
                }
            );
        }
    }
}
