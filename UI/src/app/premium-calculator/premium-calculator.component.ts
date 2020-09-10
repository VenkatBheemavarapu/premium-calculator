import { Component, OnInit, ViewChild, AfterViewChecked } from '@angular/core';
import { PremiumCalculatorService } from '../Service/premium-calculator.service';
import { Occupation } from '../Class/occupation';
import { NgForm } from '@angular/forms';
import { PremiumParameters } from '../Class/premiumparameters';
import { isNumber } from 'util';

@Component({
  selector: 'app-premium-calculator',
  templateUrl: './premium-calculator.component.html',
  styleUrls: ['./premium-calculator.component.less']
})
export class PremiumCalculatorComponent implements OnInit, AfterViewChecked {

  @ViewChild('premiumForm', {static: false}) currentForm: NgForm;
  premiumForm: NgForm;
  monthlyPremium = 0.0;
  isError: boolean = false;
  allOccupations: Occupation[];
  premiumParamModel:PremiumParameters; 

  constructor(private premiumCalculatorService: PremiumCalculatorService) { }

  ngOnInit() {
    this.premiumParamModel =  new PremiumParameters();
    this.loadAllOccupations();
  }

  ngAfterViewChecked() {
    this.formChanged();
  }

  formChanged() {
    if(this.currentForm == this.premiumForm){
      return;
    }
    this.premiumForm = this.currentForm;

    if(this.premiumForm) {
      this.premiumForm.valueChanges.subscribe(
        data => this.onValueChanged(data)
      );
    }
  }

  onValueChanged(data? : any){
    if(!this.premiumForm) { return; }
    const form = this.premiumForm.form;
    for(const field in this.formErrors){
      const control = form.get(field);
      this.formErrors[field] = '';
      if(control && control.dirty &&  !control.valid){
        for(const key in control.errors){
          this.formErrors[field]+= this.validationMessages[field][key];
        }
      }
    }
  }

  formErrors = {
    'Name': '',
    'DOB': '',
    'Age': '',
    'DeathInsured':''
  }

  validationMessages = {
    'Name': {
      'required': 'Name is required.',
      'pattern': 'Only Alphabets are allowed.'
    },
    'DOB':  {
      'required': 'DOB is required.'
    },
    'Age':  {
      'required': 'Age is required.',
      'pattern': 'Age should not be negative | should not be greater than 150'
    },
    'DeathInsured': {
      'required': 'Death Sum Insured is required.',
      'pattern': 'Only Numbers are allowed.'
    },
  }

  loadAllOccupations() {
    this.premiumCalculatorService.getOccupations().subscribe(result => {
      this.allOccupations = result;
    }, error => {
        // we can catch different exceptions according to error codes
        // for now just implemented general exception
        console.log(error);
        this.isError = true;
      });
  }

  calculatePremiumValue(occupationId: number) {
    if (occupationId == 0) this.monthlyPremium = 0;
    
    this.premiumParamModel.OccupationId = occupationId;
    this.premiumCalculatorService.getPremiumValue(this.premiumParamModel)
    .then(result => {
      if(result && isNumber(result)){
        this.monthlyPremium = Number(result);
      }
    }, error => {
        console.log(error);
        this.isError = true;
    });
  }
}
