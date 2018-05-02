using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Journal.Events;
using System.IO;
using Newtonsoft.Json;



namespace Journal
{
    public class JournalReader
    {
        //C:\Dev\ED\Journal.180430195455.01.log
        public event EventHandler<JournalEventArg> JournalEventFound;
        private string _journalFile;
        List<MatItem> items = new List<MatItem>();


        public string JournalFile
        {
            get { return _journalFile; }
            set { _journalFile = value; }
        }

        private void InitializeEvents()
        {
        }

        protected virtual void OnJournalEvent(JournalEventArg e)
        {
            EventHandler<JournalEventArg> handler = JournalEventFound;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public JournalReader()
        {

        }

        public JournalReader(string jFile)
        {
            this._journalFile = jFile;
        }

        public void ScanJournal()
        {

            var fs = new FileStream(_journalFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using (var sr = new StreamReader(fs))
            {
                var s = "";
                while (sr.Peek() > 0)
                {
                    s = sr.ReadLine();
                    ProcessEntry(s);
                }
            }

            foreach (MatItem item in items)
            {
                System.Diagnostics.Debug.WriteLine("{0}\t{1}", item.Name_Localised, item.Count);
            }

        }

        private void ProcessEntry(string entry)
        {

            JsonTextReader reader = new JsonTextReader(new StringReader(entry));
            bool inEvent = false;
            string newEventName = string.Empty;


            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonToken.StartObject:
                        inEvent = false;
                        break;
                    case JsonToken.PropertyName:
                        if (reader.Value.ToString().ToLower() == "event")
                        {
                            //the next token should be the event type
                            inEvent = true;
                            newEventName = string.Empty;
                        }
                        break;
                    case JsonToken.String:
                        if (inEvent)
                        {
                            //when we get our event name we can pass the event record to a parser to populate a full object.
                            newEventName = reader.Value.ToString();
                            //Console.WriteLine(newEventName + ",");
                            //System.Diagnostics.Debug.WriteLine(newEventName + ",");
                            inEvent = false;
                            ParseEvent(entry, newEventName);

                        }
                        break;
                    default:
                        break;
                }
            }

        }

        public void ParseEvent(string eventRec, string eventName)
        {
            JournalEventArg arg = new JournalEventArg();

            arg.JournalEntry = eventRec;
            switch (eventName.ToLower())
            {
                case "fileheader":
                    //Event_Fileheader jsonObj = JsonConvert.DeserializeObject<Event_Fileheader>(eventRec);
                    arg.EventType = JournalEvents.Fileheader;
                    break;
                case "music":
                    //Event_Music jsonObj = JsonConvert.DeserializeObject<Event_Music>(eventRec);
                    arg.EventType = JournalEvents.Music;
                    break;
                case "commander":
                    //Event_Commander jsonObj = JsonConvert.DeserializeObject<Event_Commander>(eventRec);
                   arg.EventType = JournalEvents.Commander;
                    break;
                case "materials":
                    //Event_Materials jsonObj = JsonConvert.DeserializeObject<Event_Materials>(eventRec);
                    arg.EventType = JournalEvents.Materials;
                    break;

                case "materialcollected":
                    //Event_MaterialCollected jsonObj = JsonConvert.DeserializeObject<Event_MaterialCollected>(eventRec);
                    arg.EventType = JournalEvents.MaterialCollected;
                    //bool added = false;
                    //foreach (MatItem item in items)
                    //{
                    //    if (item.Name == jsonObj.Name)
                    //    {
                    //        item.Count += jsonObj.Count;
                    //        added = true;
                    //    }
                    //}
                    //if (!added)
                    //{
                    //    items.Add(new MatItem() { Name = jsonObj.Name, Count = jsonObj.Count , Name_Localised = jsonObj.Name_Localised});
                    //}
                    break;

                case "bounty":
                    //Event_Bounty jsonObj = JsonConvert.DeserializeObject<Event_Bounty>(eventRec);
                    arg.EventType = JournalEvents.Bounty;
                    //System.Diagnostics.Debug.WriteLine("\"{0}\"\t{1}", jsonObj.Target, jsonObj.TotalReward);

                    break;

                case "fsdjump":
                    Event_FSDJump jsonObj = JsonConvert.DeserializeObject<Event_FSDJump>(eventRec);
                    arg.EventType = JournalEvents.FSDJump;

                    break;

                default:
                    arg.EventType = JournalEvents.Unknown;
                    //If this is an unknow event we want to generate a class

                    break;
            }

            OnJournalEvent(arg);
        }

    }
}

