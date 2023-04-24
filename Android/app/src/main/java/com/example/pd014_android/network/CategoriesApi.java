package com.example.pd014_android.network;

import retrofit2.Call;
import retrofit2.http.GET;

import com.example.pd014_android.dto.category.CategoryItemDTO;

import java.util.List;

public interface CategoriesApi {
    @GET("/api/categories/list")
    public Call<List<CategoryItemDTO>> list();
}