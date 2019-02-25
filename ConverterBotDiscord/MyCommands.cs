using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Interactivity;
using Engine;

namespace ConverterBotDiscord
{
    public class MyCommands
    {
        [Command("hi")]
        public async Task Hi(CommandContext ctx)
        {
            await ctx.RespondAsync($"👋 Hi, {ctx.User.Mention}!");
            var interactivity = ctx.Client.GetInteractivityModule();
            var msg = await interactivity.WaitForMessageAsync(xm => 
                xm.Author.Id == ctx.User.Id && xm.Content.ToLower() == 
                "how are you", TimeSpan.FromMinutes(1));
            if (msg != null)
                await ctx.RespondAsync($"I'm fine, thank you!");
        }

        [Command("random")]
        public async Task Random(CommandContext ctx, int min, int max)
        {
            var rnd = new Random();
            await ctx.RespondAsync($"🎲 Your random number is: {rnd.Next(min, max)}");
        }

        [Command("convert")]
        public async Task StartConvert(CommandContext ctx)
        {
            await ctx.RespondAsync($"Starting convert program.");
            Dictionary<string, string> measurements = new Dictionary<string, string>
            {
                { "temp", "temperature" },
                { "len", "length" },
                { "m", "mass" },
                { "spd", "speed" }
            };
            
            UnitFactory unitFactory = new UnitFactory();
            await ctx.RespondAsync($"The measurement types that can be used:\n" +
                $" - Temperature (temp)\n" +
                $" - Length (len)\n" +
                $" - Mass (m)\n" +
                $" - Speed (spd)\n" +
                $"\n" +
                $"What measurement type do you wish to convert? Type the short name.");
            var interactivity = ctx.Client.GetInteractivityModule();
            var msg = await interactivity.WaitForMessageAsync(xm => xm.Author.Id ==
                ctx.User.Id, TimeSpan.FromMinutes(3));
            if (msg != null)
            {
                await ctx.RespondAsync($"Received: {msg.Message.Content}");
                Console.WriteLine(msg.Message.Content);
                if (measurements.ContainsKey(msg.Message.Content))
                {
                    await ctx.RespondAsync($"{measurements[msg.Message.Content]}");
                    Console.WriteLine(measurements[msg.Message.Content]);

                    Unit unit = unitFactory.GetUnit(measurements[msg.Message.Content]);

                    // Print Info of measurement unit selected.
                    await ctx.RespondAsync($"Your choices:\n{unit.UnitInfo()}");
                }
                else
                {
                    await ctx.RespondAsync($"Wrong input! Aborting program!");
                }
            }
            else
            {
                await ctx.RespondAsync($"No message received");
            }
        }
    }
}
