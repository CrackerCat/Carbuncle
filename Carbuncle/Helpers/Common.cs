﻿using Microsoft.Office.Interop.Outlook;
using System;

namespace Carbuncle.Helpers
{
	public class Common
	{
		public static bool display = false;
		public static bool force = false;
		public static void DisplayMailItem(MailItem item)
		{
			try {
				Console.WriteLine("[Sender] {0} - ({1})", item.SenderName, item.SenderEmailAddress);
				Console.WriteLine("[Subject] " + item.Subject);
				Console.WriteLine("[ID] " + item.EntryID);
				if (item.Attachments.Count > 0)
				{
					Console.Write("[Attachments]");
					foreach (Attachment attach in item.Attachments)
					{
						Console.Write(" " + attach.FileName);
					}
					Console.WriteLine();
				}

				if (Common.display)
					Console.WriteLine("[Body] " + item.Body);
			}
			catch(System.Exception e){
				Console.WriteLine("[ERROR] " + e.Message);
			}

            Console.WriteLine();
        }
        public static void DisplayMeetingItem(MeetingItem item)
        {
			try
			{
				Console.WriteLine("[Sender] {0} - ({1})", item.SenderName, item.SenderEmailAddress);
				Console.WriteLine("[Subject] " + item.Subject);
				Console.WriteLine("[ID] " + item.EntryID);
				if (item.Attachments.Count > 0)
				{
					Console.Write("[Attachments]");
					foreach (Attachment attach in item.Attachments)
					{
						Console.Write(" " + attach.FileName);
					}
					Console.WriteLine();
				}
				if (Common.display)
					Console.WriteLine("[Body] " + item.Body);
			}
			catch(System.Exception e){
				Console.WriteLine("[ERROR] " + e.Message);
			}

			Console.WriteLine();
        }
        public static void PrintHelp()
        {

            string helptext = @"Carbuncle Usage:
carbuncle.exe <action> <action arguments>

Actions:
	searchmail		Search for an e-mail in the users inbox
	attachments		Search for and download attachments
	read			Read a specific e-mail item
	send			Send an e-mail
	monitor			Monitor for new e-mail items

read:
	/entryid:		Read an e-mail by its specific unique ID
					carbuncle.exe read /entryid:00000000ABF08F38F774EF44BD800D54DA6135740700438C90E5F1E27549A26DD4C4CE7C884C0069B971A0EB00007E3487BFEF2F834F93D188D339E4EA4E00003BA5A49B0000
	
	/number:		Readn an e-mail by its numerical position in the inbox.
					carbuncle.exe read /number:3
					
	/subject		Read an e-mail by its subject
					carbuncle.exe read /subject:""Password Reset 05/20/2021""
					
	
searchmail:
	Search Types:
	/body			Search by the content of the body. Supported search methods: /regex and /content
					carbuncle.exe searchmail /body /content:""Password"" [/display]
					
	/senderaddress	Search by sender address. Supported search methods: /regex and /address
					carbuncle.exe searchmail /senderaddress:""checkymander@protonmail.com"" [/display]
					
	/subject		Search by e-mail subject. Supported search methods: /regex and /content
					carbuncle.exe searchmail /subject /regex:""(checky).+"" [/display]
	
	/attachment		Search by e-mail attachment. Supported serach methods: /regex and /name
					carbuncle.exe searchmail /regex:""(id_rsa).+"" /downloadpath:""C:\\temp\\"" [/display]
	
	/all			Gets all e-mails
					carbuncle.exe /all [/display]
	
	Optional Flags:
	/display 		Display the body of any matched e-mail.
	/downloadpath	Download any matching attachments to the specified location

monitor:
	Optional:
	/regex			Can specify a regex to only notify on new e-mails that match a specific regex
					carbuncle.exe monitor /regex:(id_rsa) [/display]
	
	/display		Display the e-mails in console as they arrive.
					carbuncle.exe monitor /display
					
attachments
	/all			Downloads all attachments to the specified download folder
					carbuncle.exe attachments /downloadpath:""C:\\temp\\"" /all
					
	/entryid		Download attachment from a specified e-mail
					carbuncle.exe attachments /downloadpath:""C\\temp\\"" /entryid:00000000ABF08F38F774EF44BD800D54DA6135740700438C90E5F1E27549A26DD4C4CE7C884C0069B971A0EB00007E3487BFEF2F834F93D188D339E4EA4E00003BA5A49B0000

send
	/subject		Sets the subject of the e-mail
 
	/recipients		A comma separated list of recipients for the e-mail to be sent to

	/body			Body of the e-mail to send.
			
	/attachment		The local file of the attachment to be included in the e-mail

	/attachmentname	(Optional) The name of the attachment. The default is the name of the file without the extension.
					carbuncle.exe send /subject:""test e-mail please ignore"" /recipients:""email1@domain.com,email2@domain.com"" /body:""Hello World"" /attachment:""C:\\temp\\attachment.exe"" /attachmentname:""Totally Legitimate""
";

            Console.WriteLine(helptext);
        }
    }
}
