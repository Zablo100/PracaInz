import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';


@Component({
  templateUrl: './document-page.component.html',
  styleUrls: ['./document-page.component.css']
})
export class DocumentPageComponent implements OnInit {
  pdfSrc: any
  PageLoaded: boolean = false
  constructor(private http: HttpClient, public sanitizer: DomSanitizer, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.fetchPdf();
  }

  fetchPdf(){
    const id = this.route.snapshot.paramMap.get('id')
    if(id != null){
      this.http.get('https://localhost:7096/Document/GetManualDocumentById/' + id, {responseType: 'arraybuffer'}).subscribe((response) => {
        var blob = new Blob([response], {type: 'application/pdf'})
        this.pdfSrc = URL.createObjectURL(blob)
        this.PageLoaded = true
      })
    }
  }

}
