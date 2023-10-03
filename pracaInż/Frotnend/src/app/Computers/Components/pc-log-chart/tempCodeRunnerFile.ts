      const id = this.route.snapshot.paramMap.get('id')
      this.service.getPcLogsById(id).subscribe((response) => {
        this.pcLogs = response as log[]
        
        this.castDate()
        this.countData()
        this.createChart()
      })