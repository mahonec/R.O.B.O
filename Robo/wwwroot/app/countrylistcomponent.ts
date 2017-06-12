import { Component } from 'angular/core';
import { DataService } from './dataservice';
import { Country } from './country';
import { Province } from './province';

@Component({
    selector: 'my-country-list',
    templateUrl: 'app/CountryTemplate.html',
    providers: [DataService]
})
export class CountryListComponent {
    selectedCountry: Country = new Country(0, 'India');
    countries: Country[];
    provinces: Province[];

    constructor(private _dataService: DataService) {
        this._dataService.getCountries().subscribe(data => { this.countries = data });
    }

    onSelect(countryid) {
        if (countryid == 0)
            this.provinces = null;
        else
            this._dataService.getProvinces(countryid).subscribe(data => { this.provinces = data });
    }
}