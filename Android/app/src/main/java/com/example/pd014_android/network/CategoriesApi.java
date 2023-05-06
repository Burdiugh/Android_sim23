package com.example.pd014_android.network;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.POST;

import com.example.pd014_android.dto.dto.category.CategoryCreateDTO;
import com.example.pd014_android.dto.dto.category.CategoryItemDTO;

import java.util.List;

public interface CategoriesApi {
    @GET("/api/categories/list")
    public Call<List<CategoryItemDTO>> list();

    @POST("/api/categories/create")
    public Call<Void> create (@Body CategoryCreateDTO model);
}