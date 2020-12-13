package com.example.test1;

import android.os.AsyncTask;
import android.os.Bundle;
import android.os.Handler;
import android.util.Log;
import android.view.View;
import android.widget.ProgressBar;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;

import java.io.IOException;

import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.Response;

public class AsyncTest extends AppCompatActivity {
    private TextView textView;
    private ProgressBar progressBar;
    private Handler handler = new Handler();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_async_test);
        textView = findViewById(R.id.textView);
        progressBar = findViewById(R.id.progressBar);


    }

    class DownLoadTask extends AsyncTask<Void, Integer, Void> {
        @Override
        protected Void doInBackground(Void... voids) {
            for (int i = 0; i <= 100; i++) {
                try {
                    Thread.sleep(50);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
                publishProgress(i);
            }
            return null;
        }

        @Override
        protected void onProgressUpdate(Integer... values) {
            textView.setText(values[0]+"%");
            progressBar.setProgress(values[0]);
        }
    }

    public void download(View view) throws InterruptedException {
        // 순차 execute() 동시 executeOnExecutor()
        new DownLoadTask().executeOnExecutor(AsyncTask.THREAD_POOL_EXECUTOR);
        new HttpAsyncTask().executeOnExecutor(AsyncTask.THREAD_POOL_EXECUTOR,"https://goo.gl/eIXu9l");
    }

    private class HttpAsyncTask extends AsyncTask<String, Void, String> {
        OkHttpClient client = new OkHttpClient();

        @Override
        protected String doInBackground(String... strings) {
            String result = null;
            String url = strings[0];
            try {
                Request request = new Request.Builder()
                        .url(url)
                        .build();
                Response response = client.newCall(request).execute();
                result = response.body().string();
            } catch (IOException e) {
                e.printStackTrace();
            }
            return result;
        }

        @Override
        protected void onPostExecute(String s) {
            super.onPostExecute(s);
            Log.d("httpAsyncTest", s);
        }
    }
}