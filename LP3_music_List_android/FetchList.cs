using System;
using System.Linq;

using System.Net;
using System.Json;
using System.IO;

using System.Collections.Generic;
using Android.App;

namespace LP3_music_List_android
{
    class FetchList : ListActivity
    {
        static List<string> listOfSongs; //= new List<string>();

        internal void GetSite(string urlToGet = null)
        {
            Console.WriteLine("GRDU FetchList::GetSite() ");
            string lp3Url;

            if (urlToGet == null)
            {
                lp3Url = String.Format("http://lp3.polskieradio.pl/notowania/");
            }
            else
            {
                lp3Url = urlToGet;
            }

            var httpReq = (HttpWebRequest)HttpWebRequest.Create(new Uri(lp3Url));
            httpReq.BeginGetResponse(new AsyncCallback(ResponseCallBack), httpReq);
        }

        void ResponseCallBack(IAsyncResult ar)
        {
            Console.WriteLine("GRDU FetchList::ResponseCallBack() ");
            HttpWebRequest httpReq = (HttpWebRequest)ar.AsyncState;

            using (var httpRes = (HttpWebResponse)httpReq.EndGetResponse(ar))
            {
                ParseResult(httpRes);
            }
        }


        void ParseResult(HttpWebResponse httpRes)
        {
            Console.WriteLine("GRDU FetchList::ParseResult() ");
            Console.WriteLine ("GRDU " + httpRes.ContentLength);
            Stream s = httpRes.GetResponseStream();
            s.ToString();
            Console.WriteLine("GRDU FetchList::ParseResult() 2");
            JsonObject.Load(s);
            Console.WriteLine("GRDU FetchList::ParseResult() 2.1");
            JsonObject jsonObject = (JsonObject)JsonObject.Load(s);

            Console.WriteLine("GRDU FetchList::ParseResult() 3");

            var results = (from result in (JsonArray)jsonObject["result"] let jResult = result as JsonObject select jResult["text"].ToString()).ToArray();

            RunOnUiThread(() =>
            {
                PopulateLp3List(results);
            });


        }

        void PopulateLp3List(string[] results)
        {
            Console.WriteLine("GRDU FetchList::PopulateLp3List() ");
            //  results.
            listOfSongs = new List<string>(results);
            //ListAdapter = new ArrayAdapter<string>(this, Resource.Layout.ItemView, results);
        }
    }
}