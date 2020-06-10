import axios from 'axios';
import { API_URL } from '../constants';

export class TransactionService {
    static bulkUpload(transactionsFile) {
        var bodyFormData = new FormData();
        bodyFormData.append('file', transactionsFile);
    
        axios.post(`${API_URL}/api/Transaction/BulkUpload`, bodyFormData)
            .then(res => {
                console.log(res);
                console.log(res.data);
            })
    }
}