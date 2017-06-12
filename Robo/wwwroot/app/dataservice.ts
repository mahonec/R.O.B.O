import { Injectable } from '@angular2/core';
import { Http, URLSearchParams } from "angular2/http";
import 'rxjs/Rx';
import { Country } from './country';
import { Province } from './province';


@Injectable()
export class DataService {
    constructor(public http: Http) {
        this.http = http;
    }
    getCountries() {
        return this.http.get("/api/Home/GetCountries")
            .map((responseData) => responseData.json());
    }

    getProvinces(countryid: string) {
        var params = new URLSearchParams();
        params.set('countryid', countryid);
        return this.http.get("/api/Home/GetProvince", { search: params })
            .map((responseData) => responseData.json());
    }
}