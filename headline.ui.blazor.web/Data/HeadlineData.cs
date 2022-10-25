using headline.common.Models;
using System.Text;
using System.Text.Json;

namespace headline.ui.blazor.web.Data
{
    public class HeadlineData : IHeadlineData
    {
        private string mockDataBase64 = "WwogIHsKICAgICJpZCI6IDEsCiAgICAiYmFubmVyIjogIkJlZm9yZSB5b3UgbWFycnkgYSBwZXJzb24sIHlvdSBzaG91bGQgZmlyc3QgbWFrZSB0aGVtIHVzZSBhIGNvbXB1dGVyIHdpdGggc2xvdyBJbnRlcm5ldCB0byBzZWUgd2hvIHRoZXkgcmVhbGx5IGFyZS4iLAogICAgImJhY2tncm91bmRDb2xvdXIiOiAiI2MwYzBjMCIsCiAgICAiZm9yZWdyb3VuZENvbG91ciI6ICIjMDAwMDAwIiwKICAgICJpbWFnZVVybCI6ICJodHRwczovL3VwbG9hZC53aWtpbWVkaWEub3JnL3dpa2lwZWRpYS9jb21tb25zL3RodW1iL2MvYzIvV2lsbF9GZXJyZWxsXzIwMTIuanBnLzMzMHB4LVdpbGxfRmVycmVsbF8yMDEyLmpwZyIsCiAgICAiYWN0aXZlIjogdHJ1ZQogIH0sCiAgewogICAgImlkIjogMiwKICAgICJiYW5uZXIiOiAiSeKAmW0gbm90IGluc2FuZS4gTXkgbW90aGVyIGhhZCBtZSB0ZXN0ZWQuIiwKICAgICJiYWNrZ3JvdW5kQ29sb3VyIjogIiMwMDAwMDAiLAogICAgImZvcmVncm91bmRDb2xvdXIiOiAiI2ZmZmZmZiIsCiAgICAiaW1hZ2VVcmwiOiAiaHR0cHM6Ly93d3cubWFnaWNhbHF1b3RlLmNvbS93cC1jb250ZW50L3VwbG9hZHMvMjAxNS8wMy9TaGVsZG9uLUNvb3Blci5qcGciLAogICAgImFjdGl2ZSI6IHRydWUKICB9LAogIHsKICAgICJpZCI6IDMsCiAgICAiYmFubmVyIjogIkV2ZXJ5dGhpbmcgeW91IHJlYWQgb24gdGhlIGludGVybmV0IGlzIHRydWUuIiwKICAgICJiYWNrZ3JvdW5kQ29sb3VyIjogIiNmZmZmZmYiLAogICAgImZvcmVncm91bmRDb2xvdXIiOiAiIzAwMDAwMCIsCiAgICAiaW1hZ2VVcmwiOiAiaHR0cHM6Ly91cGxvYWQud2lraW1lZGlhLm9yZy93aWtpcGVkaWEvY29tbW9ucy90aHVtYi9hL2FiL0FicmFoYW1fTGluY29sbl9PLTc3X21hdHRlX2NvbGxvZGlvbl9wcmludC5qcGcvMzMwcHgtQWJyYWhhbV9MaW5jb2xuX08tNzdfbWF0dGVfY29sbG9kaW9uX3ByaW50LmpwZyIsCiAgICAiYWN0aXZlIjogdHJ1ZQogIH0sCiAgewogICAgImlkIjogNCwKICAgICJiYW5uZXIiOiAiSW5zb21uaWEgc2hhcnBlbnMgeW91ciBtYXRoIHNraWxscyBiZWNhdXNlIHlvdSBzcGVuZCBhbGwgbmlnaHQgY2FsY3VsYXRpbmcgaG93IG11Y2ggc2xlZXAgeW914oCZbGwgZ2V0IGlmIHlvdeKAmXJlIGFibGUgdG8g4oCYZmFsbCBhc2xlZXAgcmlnaHQgbm93LiIsCiAgICAiYmFja2dyb3VuZENvbG91ciI6ICIjYWEwMDAwIiwKICAgICJmb3JlZ3JvdW5kQ29sb3VyIjogIiMwMDAwMDAiLAogICAgImFjdGl2ZSI6IHRydWUKICB9LAogIHsKICAgICJpZCI6IDUsCiAgICAiYmFubmVyIjogIkl0IGlzIHRoZSB0aW1lIHlvdSBoYXZlIHdhc3RlZCBmb3IgeW91ciByb3NlIHRoYXQgbWFrZXMgeW91ciByb3NlIHNvIGltcG9ydGFudC4iLAogICAgImJhY2tncm91bmRDb2xvdXIiOiAiIzAwYWEwMCIsCiAgICAiZm9yZWdyb3VuZENvbG91ciI6ICIjMDAwMDAwIiwKICAgICJpbWFnZVVybCI6ICJodHRwczovL2lkc2IudG1ncnVwLmNvbS50ci9seS91cGxvYWRzL2ltYWdlcy8yMDIwLzA3LzA2L3RodW1icy84MDB4NTMxLzQ0NzQxLmpwZz92PTE1OTQwMzg1MTIiLAogICAgImFjdGl2ZSI6IHRydWUKICB9LAogIHsKICAgICJpZCI6IDYsCiAgICAiYmFubmVyIjogIkEgZGF5IHdpdGhvdXQgc3Vuc2hpbmUgaXMgbGlrZSBuaWdodC4iLAogICAgImJhY2tncm91bmRDb2xvdXIiOiAiIzAwYWEwMCIsCiAgICAiZm9yZWdyb3VuZENvbG91ciI6ICIjMDAwMDAwIiwKICAgICJhY3RpdmUiOiB0cnVlCiAgfSwKICB7CiAgICAiaWQiOiA2LAogICAgImJhbm5lciI6ICJIZeKAmXMgdGhlIGhlcm8gR290aGFtIGRlc2VydmVzLCBidXQgbm90IHRoZSBvbmUgaXQgbmVlZHMgcmlnaHQgbm93LiBTbyB3ZeKAmWxsIGh1bnQgaGltLi4uQmVjYXVzZSBoZSBjYW4gdGFrZSBpdC4uLkJlY2F1c2UgaGXigJlzIG5vdCBvdXIgaGVyby4gSGXigJlzIGEgc2lsZW50IGd1YXJkaWFuLCBhIHdhdGNoZnVsIHByb3RlY3Rvci4gQSBkYXJrIGtuaWdodC4iLAogICAgImJhY2tncm91bmRDb2xvdXIiOiAiIzAwYWEwMCIsCiAgICAiZm9yZWdyb3VuZENvbG91ciI6ICIjMDAwMDAwIiwKICAgICJhY3RpdmUiOiBmYWxzZQogIH0KXQo=";
        public async Task<List<Headline>> GetDataAsync()
        {
            Task.Delay(0); //Appease the compiler for now
            try
            {
                byte[] data = Convert.FromBase64String(mockDataBase64);
                string json = Encoding.UTF8.GetString(data);
                var headlineList = JsonSerializer.Deserialize<List<Headline>>(json);
                return headlineList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
