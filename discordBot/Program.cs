﻿using Discord;
using Discord.WebSocket;
using System;
using System.Collections;
using System.Threading.Tasks;

public class Program
{
	private DiscordSocketClient _client;

	public static void Main(string[] args)
		=> new Program().MainAsync().GetAwaiter().GetResult();

	public async Task MainAsync()
	{
		_client = new DiscordSocketClient();
		_client.Log += Log;
		await _client.LoginAsync(TokenType.Bot,
			"[REDACTED]");
		await _client.StartAsync();

		// Block this task until the program is closed.
		await Task.Delay(-1);
	}
	private Task Log(LogMessage msg)
	{
		Console.WriteLine(msg.ToString());
		return Task.CompletedTask;
	}
}

