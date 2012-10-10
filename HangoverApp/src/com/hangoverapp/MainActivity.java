package com.hangoverapp;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

import org.apache.http.HttpResponse;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.entity.ByteArrayEntity;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.protocol.BasicHttpContext;
import org.apache.http.protocol.HttpContext;
import org.apache.http.util.EntityUtils;
import org.json.JSONException;
import org.json.JSONObject;

import android.location.Location;
import android.location.LocationManager;
import android.os.AsyncTask;
import android.os.Bundle;
import android.os.StrictMode;
import android.app.Activity;
import android.content.Context;
import android.view.Menu;
import android.view.View;
import android.view.inputmethod.InputMethodManager;
import android.widget.EditText;
import android.widget.TextView;

public class MainActivity extends Activity {

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		new GetQuestion().execute();
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		getMenuInflater().inflate(R.menu.activity_main, menu);
		return true;
	}

	public void submitLocation(View view) {
		try
		{
		new GetLocation().execute();
		}
		catch(Exception ex){}
	}

	public void submitClick(View view) throws JSONException {
		EditText myEditText = (EditText) findViewById(R.id.editText1);
		JSONObject answer = new JSONObject();

		answer.put("answer", myEditText.getText());
		new PostAnswer().execute(answer.toString());
		InputMethodManager imm = (InputMethodManager) getSystemService(Context.INPUT_METHOD_SERVICE);
		imm.hideSoftInputFromWindow(myEditText.getWindowToken(), 0);
	}
	
	private class GetLocation extends AsyncTask<String, Void, String> {
		@Override
		protected String doInBackground(String... params) {
			try {
				LocationManager mlocManager = (LocationManager) getSystemService(Context.LOCATION_SERVICE);
				Location loc = mlocManager.getLastKnownLocation(LocationManager.GPS_PROVIDER);
				return Double.toString(loc.getLatitude());
			} catch (Exception ex) {
				return ex.toString();
			}
		}

		@Override
		protected void onPostExecute(String result) {
			
			TextView results = (TextView) findViewById(R.id.answerResult);
			results.setText(result);
		}

		@Override
		protected void onPreExecute() {
		}

	}


	private class PostAnswer extends AsyncTask<String, String, String> {
		@Override
		protected String doInBackground(String... params) {
			try {
				String result = "";
				HttpClient httpclient = new DefaultHttpClient();
				HttpPost httppost = new HttpPost(
						"http://hangoverhunt.apphb.com/player/CheckResult");
				httppost.setEntity(new ByteArrayEntity(params[0].toString()
						.getBytes("UTF8")));
				httppost.setHeader("Content-Type", "application/json");
				HttpResponse response = httpclient.execute(httppost);
				return EntityUtils.toString(response.getEntity());
			} catch (Exception ex) {
				return ex.toString();
			}
		}

		@Override
		protected void onPostExecute(String result) {
			if (result.equalsIgnoreCase("true")) {
				TextView results = (TextView) findViewById(R.id.answerResult);
				results.setText("Answer correct! Next question will now load");
				new GetQuestion().execute();

			} else {
				TextView results = (TextView) findViewById(R.id.answerResult);
				results.setText("Your answer was incorrect. Please try again");
			}
		}

		@Override
		protected void onPreExecute() {
		}

	}

	private class GetQuestion extends AsyncTask<String, Void, String> {
		@Override
		protected String doInBackground(String... params) {
			String result = "";
			try {
				HttpClient httpClient = new DefaultHttpClient();
				HttpContext localContext = new BasicHttpContext();
				HttpGet httpGet = new HttpGet(
						"http://hangoverhunt.apphb.com/player/getquestion");
				HttpResponse response = httpClient.execute(httpGet,
						localContext);

				BufferedReader reader = new BufferedReader(
						new InputStreamReader(response.getEntity().getContent()));

				String line = null;
				while ((line = reader.readLine()) != null) {
					result += line + "\n";
				}

				// {"Question":"q"}
				JSONObject json = new JSONObject(result);
				return "Question : " + json.getString("Question");
			} catch (Exception ex) {
				return ex.toString();
			}

		}

		@Override
		protected void onPostExecute(String result) {
			TextView results = (TextView) findViewById(R.id.results);
			results.setText(result);
		}

		@Override
		protected void onPreExecute() {
		}

		@Override
		protected void onProgressUpdate(Void... values) {
		}
	}
}
