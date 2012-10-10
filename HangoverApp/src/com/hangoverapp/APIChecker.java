package com.hangoverapp;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.URL;
import java.net.URLConnection;

import org.apache.http.HttpResponse;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.protocol.BasicHttpContext;
import org.apache.http.protocol.HttpContext;

import android.widget.TextView;

public class APIChecker {

	public APIChecker() {
	}

	public void GetQuestion() {
		String result = "";
		try {
			HttpClient httpClient = new DefaultHttpClient();
			HttpContext localContext = new BasicHttpContext();
			HttpGet httpGet = new HttpGet("http://www.spartanjava.com");
			HttpResponse response = httpClient.execute(httpGet, localContext);
			
			 
			BufferedReader reader = new BufferedReader(
			    new InputStreamReader(
			      response.getEntity().getContent()
			    )
			  );
			 
			String line = null;
			while ((line = reader.readLine()) != null){
			  result += line + "\n";
			}
			
			
		} catch (Exception ex) {
			result = ex.toString();
		}
		
	}
}
