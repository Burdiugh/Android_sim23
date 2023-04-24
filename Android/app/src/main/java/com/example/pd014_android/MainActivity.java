package com.example.pd014_android;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.ImageView;

import com.bumptech.glide.Glide;
import com.bumptech.glide.request.RequestOptions;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        ImageView iv = findViewById(R.id.imageView);
        String url = "http://10.0.2.2:5047/images/1.jpg";
        Glide.with(this)
                .load(url)
                .apply(new RequestOptions().override(600))
                .into(iv);
    }
}