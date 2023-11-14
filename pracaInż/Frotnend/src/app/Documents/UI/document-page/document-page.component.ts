import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DomSanitizer } from '@angular/platform-browser';


@Component({
  templateUrl: './document-page.component.html',
  styleUrls: ['./document-page.component.css']
})
export class DocumentPageComponent implements OnInit {
  pdfSrc: any
  constructor(private http: HttpClient, public sanitizer: DomSanitizer) { }

  ngOnInit(): void {
    this.fetchPdf();
  }

  fetchPdf(){
    this.http.get('https://localhost:7096/Document/GetManualDocumentById/1', {responseType: 'arraybuffer'}).subscribe((response) => {
      var blob = new Blob([response], {type: 'application/pdf'})
      this.pdfSrc = URL.createObjectURL(blob)
  })
  }

}
