const baseUri = "http://localhost:5010/api/Records"

// "https://rest---javascript-from-user-stories.azurewebsites.net/api/Records"

Vue.createApp({
    data() {
        return {
            records: [],
            error: null,
            deleteRecordId  : 0,
            deleteMessage: "",
        }
    },
    async created() {
        // created() is a life cycle method, not an ordinary method
        // created() is called automatically when the page is loaded
        console.log("created method called")
        this.helperGetRecords(baseUri)
    },
    methods: {
        async helperGetRecords(uri) {
            try {
                const response = await axios.get(uri)
                this.records = await response.data
                this.error = null
            } catch (ex) {
                this.records = []
                this.error = ex.message
            }
        },  
        async deleteRecord(deleteBib) {
            const url = baseUri + "/" + deleteBib
            try {
                const response = await axios.delete(url)
                this.deleteMessage = response.status + " " + response.statusText
                this.GetAthletes(baseUri)
            } catch (ex) {
                alert(ex.message)
            }
        },
    }
}).mount("#app")