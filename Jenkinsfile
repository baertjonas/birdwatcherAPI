pipeline {
    agent {
        dockerfile {
            filename 'Dockerfile'
            label 'myangular'
        }
    }
    stages {
        stage('Build') {
            steps {
                echo "Building..."
            }
        }
    }    
}