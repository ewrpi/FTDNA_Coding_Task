import { Component } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'fetchdata',
    templateUrl: './displaysamples.component.html'
})
export class SamplesComponent {
    public samples: Sample[];

    constructor(http: Http) {
		http.get('/api/SampleData/samples').subscribe(result => {
			this.samples = result.json() as Sample[];
        });
    }
}

interface Sample {
	barCode: string;
	createdAt: string;
    status: string;
	createdBy: string;
}
