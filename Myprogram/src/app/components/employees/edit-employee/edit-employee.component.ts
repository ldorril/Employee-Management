import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Employee } from 'src/app/models/employee.model';
import { EmployeesService } from 'src/app/services/employees.service';

@Component({
  selector: 'app-edit-employee',
  templateUrl: './edit-employee.component.html',
  styleUrls: ['./edit-employee.component.css']
})
export class EditEmployeeComponent implements OnInit {
employeeDetails: Employee = {
  id: '',
  name: '',
  email: '',
  phone: 0,
  salary: 0,
  department: ''
};
  constructor(private route: ActivatedRoute, private employeeService:EmployeesService, private router: Router) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) =>{
        const id = params.get('id');
        if(id){
          this.employeeService.getEmployee(id)
          .subscribe({
            next:(response) =>{
              this.employeeDetails = response;
            }
          });
        }
      }
    })
  }
  UpdateEmployee(){
    if(confirm("Are you sure to Edit this Employee ?")){
      this.employeeService.updateemployee(this.employeeDetails.id,this.employeeDetails)
      .subscribe({
        next: (response) =>{
          this.router.navigate(['employees']);
        }
      })
      alert("Updated Successfully")
    }
    
  }
  
  deleteEmployee(id:string){
     if(confirm("Are you sure to delete this Employee ?")){
      
       this.employeeService.deleteEmployee(id)
        
      .subscribe({
        next: (response) => {
          this.router.navigate(['employees']);
        }
      });
      alert("Deleted Successfully")
     }
   
  }
}
