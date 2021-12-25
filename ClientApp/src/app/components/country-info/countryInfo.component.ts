import { Component, OnInit } from "@angular/core";
import { DomSanitizer } from "@angular/platform-browser";
import { DynamicDialogConfig } from "primeng/dynamicdialog";
import { CountryInfo } from "src/app/models/countryInfo.model";
import { CountryService } from "src/app/services/country.service";

@Component({
    selector: "country-info",
    templateUrl: "countryInfo.component.html",
    styleUrls: [ "countryInfo.component.css" ]
})
export class CountryInfoComponent implements OnInit {
    public countryInfo?: CountryInfo;
    countryName: string = "";

    public countryFlagSrc: any;
    public isCountryFlagLoading?: boolean = false;

    public countryCoatSrc: any;
    public isCountryCoatLoading?: boolean = false;

    public countryAnthemSrc: any;
    public isCountryAnthemLoading?: boolean = false;

    constructor(
        private service: CountryService,
        public dialogConfig: DynamicDialogConfig,
        private sanitizer: DomSanitizer
    ) { }

    public ngOnInit() {
        this.countryName = this.dialogConfig.data.countryName;
        if (this.countryName) {
            this.loadCountyInfo(this.countryName);
            this.loadCountryFlag(this.countryName);
            this.loadCountryCoat(this.countryName);
            this.loadCountryAnthem(this.countryName);
        }
    }

    private loadCountyInfo(countryName: string) {
        this.service.getCountryInfo(countryName)
            .subscribe(
                data => this.countryInfo = data,
                error => console.log(error));
    }

    private loadCountryFlag(countryName: string) {
        this.isCountryFlagLoading = true;
        this.service.getCountryFlag(countryName)
            .subscribe(
                data => {
                    this.createFileFromBlob(data, "flag");
                    this.isCountryFlagLoading = false;
                },
                error => {
                    this.isCountryFlagLoading = false;
                    console.log(error);
                });
    }

    private loadCountryCoat(countryName: string) {
        this.isCountryCoatLoading = true;
        this.service.getCountryCoat(countryName)
            .subscribe(
                data => {
                    this.createFileFromBlob(data, "coat");
                    this.isCountryCoatLoading = false;
                },
                error => {
                    this.isCountryCoatLoading = false;
                    console.log(error);
                });
    }

    private loadCountryAnthem(countryName: string) {
        this.isCountryAnthemLoading = true;
        this.service.getCountryAnthem(countryName)
            .subscribe(
                data => {
                    this.createFileFromBlob(data, "anthem");
                    this.isCountryAnthemLoading = false;
                },
                error => {
                    this.isCountryAnthemLoading = false;
                    console.log(error);
                });
    }

    private createFileFromBlob(file: Blob, resource: string) {
        let reader = new FileReader();
        reader.addEventListener("load", () => {
            switch (resource) {
                case "flag":
                    this.countryFlagSrc = reader.result;
                    break;
                case "coat":
                    this.countryCoatSrc = reader.result;
                    break;
                case "anthem":
                    this.countryAnthemSrc = reader.result;
                    break;

                default:
                    break;
            }
        }, false);

        if (file) {
            reader.readAsDataURL(file);
        }
    }

    sanitize(url: string) {
        return this.sanitizer.bypassSecurityTrustUrl(url);
    }
}