import { Component, OnInit } from '@angular/core';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { CountriesService } from 'src/app/services/countries.service';

@Component({
  selector: 'app-theoty-panel',
  templateUrl: './theoty-panel.component.html',
  styleUrls: ['./theoty-panel.component.scss']
})
export class TheotyPanelComponent implements OnInit {

  countryName = '';
  links: { url: string; description: string } [] = [];
  flagLoaded = false;
  finalpath = '';

  constructor(
    private countryService: CountriesService,
    public ref: DynamicDialogRef,
    public config: DynamicDialogConfig
  ) { }

  ngOnInit(): void {
    this.countryName = this.config.data.countryName;
    this.countryService.getInfo(this.countryName)
      .subscribe(
        data => {
          console.log(data);
          this.links = data.links || [];
        }, 
        err => console.log(err)
      )
      this.countryService.getFlag(this.countryName)
      .subscribe(
        data => {
          console.log(data);
          this.finalpath = URL.createObjectURL(data);//.replace(/blob:/g, "");
          this.flagLoaded = true;
        }, 
        err => console.log(err)
      )
  }

}
