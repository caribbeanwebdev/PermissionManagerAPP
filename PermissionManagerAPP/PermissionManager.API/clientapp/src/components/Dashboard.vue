<template>
  <div id="dashboard">
    <form @submit.prevent="add">

        <div class="input-group mb-3">
          <input type="hidden" v-model="form.id">
          <input type="text" class="form-control rounded" placeholder="employeeName.."  v-model="form.employeeName">
          <input type="text" class="form-control rounded ml-3" maxlength="50" placeholder="employeeLastName.."  v-model="form.employeeLastName">
          <select v-model="form.permissionType" >
            <option disabled value="0">permissionType</option>
            <option v-for="option in options" v-bind:value="option.value">
              {{ option.text }}
            </option>
          </select>
          <input type="date" class="form-control rounded ml-3" maxlength="50" v-model="form.permissionDate">
          <button class="btn btn-primary col-sm-12 col-md-2 mt-3 mt-md-0 ml-md-3" type="submit" v-show="!updateSubmit" :disabled="loading">Add</button>
          <button class="btn btn-primary col-sm-12 col-md-2 mt-3 mt-md-0 ml-md-3" type="button" v-show="updateSubmit" @click="update(form)">Update</button>
        </div>

    </form>

    <div class="row">
      <div class="col-12 d-flex justify-content-start align-items-start flex-row flex-wrap">

        <div class="card col-12 col-md-6 col-lg-4" style="border-radius: 0;" v-for="permission in permissions" :key="permission.id">
          <div class="card-body">
            <h5 class="card-title">{{permission.employeeName}}</h5>
            <p class="card-text border-primary pl-2" style="border-left: 1.5px solid">{{permission.employeeLastName}}</p>
            <p class="card-text border-primary pl-2" style="border-left: 1.5px solid">{{permission.permissionType}}</p>
            <p class="card-text border-primary pl-2" style="border-left: 1.5px solid">{{permission.permissionDate}}</p>
            <button class="btn btn-primary mb-1 mb-md-0 mr-md-1 col-12 col-md-5" @click="edit(permission)">Edit</button>
            <button class="btn btn-danger mt-1 mt-md-0 ml-md-1 col-12 col-md-5" @click="del(permission)">Delete</button>
          </div>
        </div>
   
      </div>
    </div>

  </div>
</template>

<script>
import axios from 'axios'

export default {
  data(){
    return{
        form: {
          id: 0,
          employeeName: '',
          employeeLastName: '',
          permissionType: 0,
          permissionDate: '',
        },
        permissions: [],
        options: [
          { text: 'Disease', value: 1 },
          { text: 'Diligence', value: 2 },
          { text: 'Study', value: 3 }
        ],
        loading: false,
        updateSubmit: false
    }
  },
  mounted(){
    this.load();
  },
  methods: {
    load(){
  		axios({
  			method: 'get',
  			url: 'http://localhost:9090/api/permission/'
  		})
  		.then(res => {
  			this.permissions = res.data
  		})
  		.catch ((err) => {
  			this.alertError()
  		})
    },
    add(){
      if (
          !this.form.employeeName ||
          !this.form.employeeLastName ||
          !this.form.permissionType ||
          !this.form.permissionDate
      ) {
        this.$swal({
          type: "warning",
          title: "Missing required values"
        });
        return;
      }
    	axios({
  		  method: 'post',
  		  url: 'http://localhost:9090/api/permission/',
  		  data: {
          id: 0,
          employeeName: this.form.employeeName,
          employeeLastName: this.form.employeeLastName,
          permissionType: parseInt(this.form.permissionType),
          permissionDate: this.form.permissionDate,
        }
		  })
      .then(res => {
        this.load()
        this.form.employeeName = ''
        this.form.employeeLastName = ''
        this.form.permissionType = 0
        this.form.permissionDate = ''
        this.alertSuccess()
      })
    },
    edit(permission){ 
      this.updateSubmit = true
      this.form.id = permission.id 
      this.form.employeeName = permission.employeeName 
      this.form.employeeLastName = permission.employeeLastName 
      this.form.permissionType = permission.permissionType 
      this.form.permissionDate = permission.permissionDate 
    },
    update(form){
    	axios({
  		  method: 'put',
  		  url: 'http://localhost:9090/api/permission/' + form.id,
  		  data: {
          id: form.id, 
          employeeName: this.form.employeeName,
          employeeLastName: this.form.employeeLastName,
          permissionType: this.form.permissionType,
          permissionDate: this.form.permissionDate
          }
		  })
      .then(res => {
        this.load()
        this.form.id = 0
        this.form.employeeName = ''
        this.form.employeeLastName = ''
        this.form.permissionType = 0
        this.form.permissionDate = ''
        this.updateSubmit = false
        this.alertSuccess()
      })
    },
    del(permission){
        this.$swal({
            type: "warning",
            title: "Are you sure?",
            showCancelButton: true,
            confirmButtonText: `Delete`,
          }).then((result) => {
            
              axios({
                method: 'delete',
                url: 'http://localhost:9090/api/permission/' + permission.id,	
              })
              .then(res =>{
                this.load()
                this.form.id = ''
                this.form.employeeName = ''
                this.form.employeeLastName = ''
                this.form.permissionType = ''
                this.form.permissionDate = ''
                this.updateSubmit = false
                let index = this.permissions.indexOf(this.form.name)
                this.permissions.splice(index,1)
                this.alertSuccess()
              })
          });
        
    },
    alertSuccess(){
        this.$swal({
           type: 'success',
            title: 'Success',
            text: 'All ok!',
        });
    },
    alertError(){
        this.$swal({
           type: 'error',
            title: 'Oops...',
            text: 'Something went wrong!',
        });
    }

  }
}
</script>
