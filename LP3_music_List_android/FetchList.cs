using System;
using System.Linq;

using System.Net;
using System.Json;
using System.IO;


using Android.App;

namespace LP3_music_List_android
{
    class FetchList : ListActivity
    {


        void GetSite(string urlToGet = null)
        {
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


        void ResponseCallBack (IAsyncResult ar )
        {
            HttpWebRequest httpReq = (HttpWebRequest)ar.AsyncState;

            using (var httpRes = (HttpWebResponse)httpReq.EndGetResponse(ar))
            {
                ParseResult(httpRes);
            }
        }


        void ParseResult(HttpWebResponse httpRes)
        {
            Stream s = httpRes.GetResponseStream();
            JsonObject jsonObject = (JsonObject)JsonObject.Load(s);
            

            var results = (from result in (JsonArray ) jsonObject ["result"] let jResult = result as JsonObject select jResult["text"].ToString ()).ToArray();
           
            RunOnUiThread(() => {
               PopulateLp3List(results);
           });


        }
        
        void PopulateLp3List (string [] results)
        {
            //ListAdapter = new ArrayAdapter<string>(this, Resource.Layout.ItemView, results);
        }
    }
}