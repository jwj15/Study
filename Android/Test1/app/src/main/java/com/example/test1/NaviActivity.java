package com.example.test1;

import android.os.Bundle;

import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;

public class NaviActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_navi);
        ActionBar actionBar = getSupportActionBar();
        actionBar.setTitle("NaviText");
        actionBar.setDisplayHomeAsUpEnabled(true);
    }
}