import axios from 'axios';
import IHat from '../types/Hat';

export default class HatService{
    API_URL = process.env.VUE_APP_API_URL;

    public async createHat(): Promise<any>{
        let result = await axios.get(`http://192.168.0.101:45456/CreateHat`, {params: {hatName: 'test'}});
        return result;
    }
    
    public async gatHats(): Promise<IHat[]>{
        let result = await axios.get(`http://192.168.0.101:45456/GetHats/`);
        return result.data;
    }
}