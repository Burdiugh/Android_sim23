package com.example.pd014_android.network;

import com.example.pd014_android.dto.dto.account.RegisterDTO;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.POST;

public interface AccountApi {

    @POST("/api/account/register")
    public Call<Void> register(@Body RegisterDTO registerDTO);
}
