package com.example.test1;

import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

public class DisplayMessageActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_display_message);

        Intent intent = getIntent();
        String message = intent.getStringExtra("msg");
        TextView textView = new TextView(this);
        textView.setTextSize(40);
        textView.setText(message);
        ViewGroup layout = (ViewGroup) findViewById(R.id.activity_display_message);
        layout.addView(textView);

        findViewById(R.id.image_view).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Toast.makeText(DisplayMessageActivity.this, "그림 클릭!!", Toast.LENGTH_SHORT).show();
            }
        });
    }

    public void btn_click(View view) {
        Intent intent = new Intent();
        intent.putExtra("result", "되돌아오다!!");
        setResult(RESULT_OK, intent);
        finish();
    }

    public void action_call(View view) {
        Intent intent = new Intent(Intent.ACTION_DIAL);
        intent.setData(Uri.parse("tel:01042020690"));
        if (intent.resolveActivity(getPackageManager()) != null) {
            startActivity(intent);
        }


    }
}