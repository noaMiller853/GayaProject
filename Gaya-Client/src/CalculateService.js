import axios from 'axios';

const API_URL = 'https://localhost:7011/Calculate';

export const CalculateService = {

  getListOperators: async () => {
    try {
      const response = await axios.get(`${API_URL}`);
      console.log(response.data);
      
      return response.data
    } catch (error) {
      console.error('Error updating document:', error);
      throw error;
    }
  },
  addArguments: async (field1, field2, operation) => {
    const data = {
      operation: operation, 
          argument1: field1, 
          argument2: field2, 
     };
    try {
      const response = await axios.post(`${API_URL}`, data);
      console.log("service",response.data);
      
      return response.data;
    } catch (error) {
      console.error('Error add argument:', error);
      throw error;
    }
  },
  getArgumentByIdOperator:async(id)=>{
    try{
    const response = await axios.post(`${API_URL}/Arguments`, {idOperator:id});
    console.log(response);
    
    return response.data;
    } catch (error) {
      console.error('Error get result:', error);
      throw error;
    }
  }

};
