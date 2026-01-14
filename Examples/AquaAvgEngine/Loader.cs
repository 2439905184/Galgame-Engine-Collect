public class Loader
{
    public static async Task<StoryLine> CompileStoryAsync(string storyCode)
    {
        try
        {
            var options = ScriptOptions.Default
                .WithReferences(typeof(StoryLine).Assembly)
                .AddImports("AquaAvgFramework",
                            "AquaAvgFramework.Animation",
                            "AquaAvgFramework.Animation.Common",
                            "AquaAvgFramework.Animation.Switch",
                            "AquaAvgFramework.GameElements.Blocks",
                            "AquaAvgFramework.GameElements.Events",
                            "AquaAvgFramework.GameElements",
                            "AquaAvgFramework.StoryLineComponents",
                            "AquaAvgFramework.Spirits",
                            "AquaAvgFramework.Global",
                            "AquaAvgFramework.Pools");

            return await CSharpScript.EvaluateAsync<StoryLine>(storyCode, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed: {ex.Message}");
            return null!;
        }
    }
}