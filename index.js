const baseUri = "https://rest---javascript-from-user-stories.azurewebsites.net/api/Records"

//"http://localhost:5010/api/Records"


Vue.createApp({
    data() {
        return {
            records: [],
            error: null,
            addData: { id: 0, title: "", artist: "", publication: "2025-08-28T00:00:00", duration: "" },
            addMessage: "",
            deleteRecordId: 0,
            deleteMessage: "",
            updateData: { id: "", title: "", artist: "", publication: "", duration: "" },
            updateMessage: ""
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
        async AddRecords() {
            try {
                response = await axios.post(baseUri, this.addData)
                this.addMessage = "response " + response.status + " " + response.statusText
                this.helperGetRecords(baseUri)
            } catch (ex) {
                alert(ex.message)
            }
        },
        async deleteRecord(deleteRecord) {
            const url = baseUri + "/" + deleteRecord
            try {
                const response = await axios.delete(url)
                this.deleteMessage = response.status + " " + response.statusText
                this.helperGetRecords(baseUri)
            } catch (ex) {
                alert(ex.message)
            }
        },
        async updateRecord() {
            const url = baseUri + "/" + this.updateData.id
            try {
                response = await axios.put(url, this.updateData)
                this.updateMessage = "response " + response.status + " " + response.statusText
                this.helperGetRecords(baseUri)
            } catch (ex) {
                alert(ex.message)
            }
        },
        sortByTitle() {
            this.helperGetRecords(baseUri + "?sort_by=title")
        },
        sortByArtist() {
            this.helperGetRecords(baseUri + "?sort_by=artist")
        },
        sortByDuration() {
            this.helperGetRecords(baseUri + "?sort_by=duration")
        },
        sortByPublication() {
            this.helperGetRecords(baseUri + "?sort_by=publication")
        },
    }
}).mount("#app")