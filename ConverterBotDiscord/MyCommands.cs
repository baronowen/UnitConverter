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
                    // Print info of measurement unit selected
                    await ctx.RespondAsync($"Your choices:\n{unit.UnitInfo()}");

                    //await ctx.RespondAsync($"Please give the from unit, to unit and value " +
                    //    $"seperated by commas.");

                    //msg = await interactivity.WaitForMessageAsync(xm => xm.Author.Id == ctx.User.Id,
                    //    TimeSpan.FromMinutes(4));
                    //if (msg != null)
                    //{

                    //}

                    // ask for from.
                    await ctx.RespondAsync($"Convert from: ");
                    msg = await interactivity.WaitForMessageAsync(xm => xm.Author.Id ==
                        ctx.User.Id, TimeSpan.FromMinutes(2));
                    if (msg != null)
                    {
                        unit.From = msg.Message.Content;
                        Console.WriteLine("From: " + unit.From);

                        // ask for to
                        await ctx.RespondAsync($"To: ");
                        msg = await interactivity.WaitForMessageAsync(xm => xm.Author.Id ==
                            ctx.User.Id, TimeSpan.FromMinutes(2));
                        if (msg != null)
                        {
                            unit.To = msg.Message.Content;
                            Console.WriteLine("To: " + unit.To);

                            // ask for value
                            await ctx.RespondAsync($"With value of: ");
                            msg = await interactivity.WaitForMessageAsync(xm => xm.Author.Id ==
                                ctx.User.Id, TimeSpan.FromMinutes(2));
                            if (msg != null)
                            {
                                unit.Value = Double.Parse(msg.Message.Content);
                                Console.WriteLine("value: " + unit.Value);

                                // calculate
                                double val = unit.Convert();
                                Console.WriteLine("Conversion resulted in: " + val + "\n");
                                await ctx.RespondAsync($"Conversion ({unit.Value + unit.From} => " +
                                    $"{unit.To}) resulted in {val + unit.To}");
                            }
                        }
                    }

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
