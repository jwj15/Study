package com.example.test1;

import android.os.Bundle;
import android.util.Log;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.RecyclerView;
import androidx.recyclerview.widget.StaggeredGridLayoutManager;

import com.example.test1.adapter.RecyclerAdapter;
import com.example.test1.data.model.CardItem;

import java.util.ArrayList;
import java.util.List;

public class CardViewActivity extends AppCompatActivity implements RecyclerAdapter.RecyclerViewClickListener {

    private RecyclerAdapter adapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_card_view);

        RecyclerView recyclerView = findViewById(R.id.recyclerView);
        RecyclerView.LayoutManager layoutManager = new StaggeredGridLayoutManager(2, StaggeredGridLayoutManager.VERTICAL);
        recyclerView.setLayoutManager(layoutManager);
        List<CardItem> dataList = new ArrayList<>();
        dataList.add(new CardItem("첫번째", "안녕하세요~~~!!"));
        dataList.add(new CardItem("두번째", "하이하이하이"));
        dataList.add(new CardItem("세번째", "ㅗㅁ뎌로며잳ㅁㅈㄷ로며23903"));
        adapter = new RecyclerAdapter(dataList);
        adapter.setOnClickListener(this);
        recyclerView.setAdapter(adapter);
    }

    @Override
    public void onItemClicked(int position) {
        Log.d("CardViewActivity", "onItemClicked :" + position);
    }

    @Override
    public void onShareButtonClicked(int position) {
        Log.d("CardViewActivity", "onShareButtonClicked :" + position);
        adapter.addItem(position, new CardItem("추가 아이템", "추가 성공!!!"));
    }

    @Override
    public void onLearnMoreButtonClicked(int position) {
        Log.d("CardViewActivity", "onLearnMoreButtonClicked :" + position);
        adapter.removeItem(position);
    }

}